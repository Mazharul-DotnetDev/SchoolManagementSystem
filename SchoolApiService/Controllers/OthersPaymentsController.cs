using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolApp.DAL.SchoolContext;
using SchoolApp.Models.DataModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SchoolApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OthersPaymentsController : ControllerBase
    {
        private readonly SchoolDbContext _context;

        public OthersPaymentsController(SchoolDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<IActionResult> GetothersPayments()
        {
            try
            {
                var othersPayments = await _context.othersPayments

                    .Include(fp => fp.otherPaymentDetails)
                    .ToListAsync();

                return Ok(othersPayments);
            }
            catch (Exception ex)
            {
                // Log the exception for debugging purposes
                Console.WriteLine($"Exception: {ex}");

                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOthersPaymentById(int id)
        {
            try
            {
                var monthlyPayment = await _context.othersPayments

                    .Include(fp => fp.otherPaymentDetails)
                    .FirstOrDefaultAsync(fp => fp.OthersPaymentId == id);

                if (monthlyPayment == null)
                {
                    return NotFound($"monthlyPayment with ID {id} not found");
                }

                return Ok(monthlyPayment);
            }
            catch (Exception ex)
            {
                // Log the exception for debugging purposes
                Console.WriteLine($"Exception: {ex}");

                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }



        // PUT: api/OthersPayments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOthersPayment(int id, OthersPayment othersPayment)
        {
            if (id != othersPayment.OthersPaymentId)
            {
                return BadRequest();
            }

            _context.Entry(othersPayment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OthersPaymentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }


        private async Task AttachFeeAsync(OthersPayment existingOthersPayment, OthersPayment updatedOthersPayment)
        {
            if (updatedOthersPayment.fees != null && updatedOthersPayment.fees.Any())
            {
                existingOthersPayment.fees = await _context.fees
                    .Where(am => updatedOthersPayment.fees.Select(m => m.FeeId).Contains(am.FeeId))
                    .ToListAsync();
            }
        }


        [HttpPost]
        public async Task<IActionResult> CreateOthersPayment([FromBody] OthersPayment othersPayment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    await AttachFeeAsync(othersPayment);
                    await CalculatePaymentFieldsAsync(othersPayment);

                    _context.othersPayments.Add(othersPayment);
                    await _context.SaveChangesAsync();

                    UpdateDueBalance(othersPayment);
                    await SavePaymentDetailAsync(othersPayment);


                    transaction.Commit();

                    return Ok(othersPayment);
                }
                catch (Exception ex)
                {
                    // Log the exception for debugging purposes
                    Console.WriteLine($"Exception: {ex}");

                    transaction.Rollback();
                    return StatusCode(500, "Internal Server Error: An error occurred while processing the request.");
                }
            }
        }

        private void UpdateDueBalance(OthersPayment othersPayment)
        {
            var dueBalance = _context.dbsDueBalance
                .Where(db => db.StudentId == othersPayment.StudentId)
                .FirstOrDefault();

            if (dueBalance != null)
            {
                dueBalance.DueBalanceAmount = othersPayment.AmountRemaining;
                dueBalance.LastUpdate = DateTime.Now; // Update LastUpdate timestamp
            }
            else
            {
                _context.dbsDueBalance.Add(new DueBalance
                {
                    StudentId = othersPayment.StudentId,
                    DueBalanceAmount = othersPayment.AmountRemaining,
                    LastUpdate = DateTime.Now // Set LastUpdate timestamp for a new record
                });
            }

            _context.SaveChanges(); // Save changes to the database
        }

        private async Task SavePaymentDetailAsync(OthersPayment othersPayment)
        {
            if (othersPayment.fees != null && othersPayment.fees.Any())
            {
                foreach (var fees in othersPayment.fees)
                {
                    var feeType = _context.dbsFeeType
                        .Where(ft => ft.FeeTypeId == fees.FeeTypeId)
                        .FirstOrDefault();
                    //var feesType = await _context.fees
                    //    .Where(ft => ft.FeeId == fees.FeeId)
                    //    .FirstOrDefaultAsync();

                    var otherPaymentDetail = new OtherPaymentDetail
                    {
                        OthersPaymentId = othersPayment.OthersPaymentId,

                        FeeAmount = fees.Amount,

                        FeeName = feeType?.TypeName
                    };

                    _context.otherPaymentDetails.Add(otherPaymentDetail);
                }

                await _context.SaveChangesAsync();
            }
        }

        private async Task CalculatePaymentFieldsAsync(OthersPayment othersPayment)
        {
            var student = await _context.dbsStudent
                .Where(s => s.StudentId == othersPayment.StudentId)
                .FirstOrDefaultAsync();

            if (student == null)
            {
                throw new Exception("Invalid Student Id: " + othersPayment.StudentId);
            }
            var studentId = othersPayment.StudentId;


            othersPayment.TotalAmount = othersPayment.fees?.Sum(fs => fs.Amount) ?? 0;

            othersPayment.AmountRemaining = othersPayment.TotalAmount - othersPayment.AmountPaid;

        }




        private async Task AttachFeeAsync(OthersPayment othersPayment)
        {
            if (othersPayment.fees != null && othersPayment.fees.Any())
            {
                othersPayment.fees = await _context.fees
                    .Where(fs => othersPayment.fees.Select(f => f.FeeId).Contains(fs.FeeId))
                    .ToListAsync();
            }
        }





        // DELETE: api/OthersPayments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOthersPayment(int id)
        {
            var othersPayment = await _context.othersPayments.FindAsync(id);
            if (othersPayment == null)
            {
                return NotFound();
            }

            _context.othersPayments.Remove(othersPayment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OthersPaymentExists(int id)
        {
            return _context.othersPayments.Any(e => e.OthersPaymentId == id);
        }
    }
}
