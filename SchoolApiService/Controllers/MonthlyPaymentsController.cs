using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolApp.DAL.SchoolContext;
using SchoolApp.Models.DataModels;



namespace SchoolApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonthlyPaymentsController : ControllerBase
    {
        private readonly SchoolDbContext _context;

        public MonthlyPaymentsController(SchoolDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetMonthlyPayments()
        {
            try
            {
                var monthlyPaments = await _context.monthlyPayments

                    .Include(fp => fp.PaymentDetails)
                    .Include(fp => fp.paymentMonths)
                    .Include(fp => fp.Student)
                    .Include(fp => fp.dueBalances)
                    .ToListAsync();

                return Ok(monthlyPaments);
            }
            catch (Exception ex)
            {
                // Log the exception for debugging purposes
                Console.WriteLine($"Exception: {ex}");

                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMonthlyPaymentById(int id)
        {
            try
            {
                var monthlyPayment = await _context.monthlyPayments

                    .Include(fp => fp.PaymentDetails)
                    .Include(fp => fp.paymentMonths)
                    .Include(fp => fp.Student)
                    .Include(fp => fp.dueBalances)
                    .FirstOrDefaultAsync(fp => fp.MonthlyPaymentId == id);

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

        // PUT: api/MonthlyPayments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMonthlyPayment(int id, [FromBody] MonthlyPayment updatedmonthlyPayment)
        {
            if (id != updatedmonthlyPayment.MonthlyPaymentId)
            {
                return BadRequest("ID Mismatch");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var existingMonthlyPayment = await _context.monthlyPayments
                        .Include(p => p.fees)
                        .Include(p => p.paymentMonths)
                        .Include(p => p.dueBalances)
                        .Include(p => p.PaymentDetails)
                        .FirstOrDefaultAsync(p => p.MonthlyPaymentId == id);

                    if (existingMonthlyPayment == null)
                    {
                        return NotFound($"Payment with ID {id} not found.");
                    }

                    existingMonthlyPayment.dueBalances.Clear();
                    // Update properties of the existing payment
                    existingMonthlyPayment.StudentId = updatedmonthlyPayment.StudentId;
                    existingMonthlyPayment.TotalFeeAmount = updatedmonthlyPayment.TotalFeeAmount;
                    existingMonthlyPayment.Waver = updatedmonthlyPayment.Waver;

                    existingMonthlyPayment.PreviousDue = updatedmonthlyPayment.PreviousDue;
                    existingMonthlyPayment.AmountPaid = updatedmonthlyPayment.AmountPaid;



                    existingMonthlyPayment.paymentMonths.Clear();
                    existingMonthlyPayment.PaymentDetails.Clear();
                    existingMonthlyPayment.dueBalances.Clear();




                    await AttachFeeAsync(existingMonthlyPayment, updatedmonthlyPayment);
                    await AttachAcademicMonthAsync(existingMonthlyPayment, updatedmonthlyPayment);

                    await CalculatePaymentFieldsAsync2(existingMonthlyPayment);
                    UpdateDueBalance(existingMonthlyPayment);



                    // Save changes to the database
                    await _context.SaveChangesAsync();

                    await SaveMonthDetailsAsync(existingMonthlyPayment);
                    await SavePaymentDetailAsync(existingMonthlyPayment);

                    transaction.Commit();

                    return Ok(existingMonthlyPayment);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception: {ex}");
                    transaction.Rollback();
                    return StatusCode(500, $"Internal Server Error: {ex.Message}");
                }
            }
        }
        private async Task CalculatePaymentFieldsAsync2(MonthlyPayment monthlyPayment)
        {
            var student = await _context.dbsStudent
                .Where(s => s.StudentId == monthlyPayment.StudentId)
                .FirstOrDefaultAsync();

            if (student == null)
            {
                throw new Exception("Invalid Student Id: " + monthlyPayment.StudentId);
            }
            var studentId = monthlyPayment.StudentId;
            var academicMonthsCount = monthlyPayment.academicMonths?.Count ?? 0;

            monthlyPayment.TotalFeeAmount = monthlyPayment.fees?.Sum(fs => fs.Amount * academicMonthsCount) ?? 0;


            //var previousDue = await _context.dbsDueBalance
            //    .Where(b => b.StudentId == studentId)
            //    .Select(b => b.DueBalanceAmount)
            //    .FirstOrDefaultAsync();

            //monthlyPayment.PreviousDue = previousDue ?? 0;
            monthlyPayment.TotalAmount = monthlyPayment.TotalFeeAmount - (monthlyPayment.TotalFeeAmount * (monthlyPayment.Waver / 100)) + monthlyPayment.PreviousDue;
            monthlyPayment.AmountRemaining = monthlyPayment.TotalAmount - monthlyPayment.AmountPaid;

        }
        private async Task AttachAcademicMonthAsync(MonthlyPayment existingMonthlyPayment, MonthlyPayment updatedMonthlyPayment)
        {
            if (updatedMonthlyPayment.academicMonths != null && updatedMonthlyPayment.academicMonths.Any())
            {
                existingMonthlyPayment.academicMonths = await _context.dbsAcademicMonths
                    .Where(am => updatedMonthlyPayment.academicMonths.Select(m => m.MonthId).Contains(am.MonthId))
                    .ToListAsync();
            }
        }

        private async Task AttachFeeAsync(MonthlyPayment existingMonthlyPayment, MonthlyPayment updatedMonthlyPayment)
        {
            if (updatedMonthlyPayment.fees != null && updatedMonthlyPayment.fees.Any())
            {
                existingMonthlyPayment.fees = await _context.fees
                    .Where(am => updatedMonthlyPayment.fees.Select(m => m.FeeId).Contains(am.FeeId))
                    .ToListAsync();
            }
        }



        [HttpPost]
        public async Task<IActionResult> CreateMonthlyPayment([FromBody] MonthlyPayment monthlyPayment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    await AttachFeeAsync(monthlyPayment);
                    await AttachAcademicMonthAsync(monthlyPayment);
                    await CalculatePaymentFieldsAsync(monthlyPayment);

                    _context.monthlyPayments.Add(monthlyPayment);
                    await _context.SaveChangesAsync();

                    UpdateDueBalance(monthlyPayment);
                    await SavePaymentDetailAsync(monthlyPayment);
                    await SaveMonthDetailsAsync(monthlyPayment);

                    transaction.Commit();

                    return Ok(monthlyPayment);
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

        private async Task SaveMonthDetailsAsync(MonthlyPayment monthlyPayment)
        {
            if (monthlyPayment.academicMonths != null && monthlyPayment.academicMonths.Any())
            {
                foreach (var academicMonth in monthlyPayment.academicMonths)
                {
                    var paymentMonth = new PaymentMonth
                    {
                        MonthlyPaymentId = monthlyPayment.MonthlyPaymentId,
                        MonthName = academicMonth.MonthName
                    };

                    _context.paymentMonths.Add(paymentMonth);
                }

                await _context.SaveChangesAsync();
            }
        }

        private async Task SavePaymentDetailAsync(MonthlyPayment monthlyPayment)
        {
            if (monthlyPayment.fees != null && monthlyPayment.fees.Any())
            {
                foreach (var fees in monthlyPayment.fees)
                {
                    var feeType = _context.dbsFeeType
                        .Where(ft => ft.FeeTypeId == fees.FeeTypeId)
                        .FirstOrDefault();
                    //var feesType = await _context.fees
                    //    .Where(ft => ft.FeeId == fees.FeeId)
                    //    .FirstOrDefaultAsync();

                    var paymentDetails = new PaymentDetail
                    {
                        MonthlyPaymentId = monthlyPayment.MonthlyPaymentId,

                        FeeAmount = fees.Amount,

                        FeeName = feeType?.TypeName
                    };

                    _context.PaymentDetails.Add(paymentDetails);
                }

                await _context.SaveChangesAsync();
            }
        }


        private async Task CalculatePaymentFieldsAsync(MonthlyPayment monthlyPayment)
        {
            var student = await _context.dbsStudent
                .Where(s => s.StudentId == monthlyPayment.StudentId)
                .FirstOrDefaultAsync();

            if (student == null)
            {
                throw new Exception("Invalid Student Id: " + monthlyPayment.StudentId);
            }
            var studentId = monthlyPayment.StudentId;
            var academicMonthsCount = monthlyPayment.academicMonths?.Count ?? 0;

            monthlyPayment.TotalFeeAmount = monthlyPayment.fees?.Sum(fs => fs.Amount * academicMonthsCount) ?? 0;


            var previousDue = await _context.dbsDueBalance
                .Where(b => b.StudentId == studentId)
                .Select(b => b.DueBalanceAmount)
                .FirstOrDefaultAsync();

            monthlyPayment.PreviousDue = previousDue ?? 0;
            monthlyPayment.TotalAmount = monthlyPayment.TotalFeeAmount - (monthlyPayment.TotalFeeAmount * (monthlyPayment.Waver / 100)) + monthlyPayment.PreviousDue;
            monthlyPayment.AmountRemaining = monthlyPayment.TotalAmount - monthlyPayment.AmountPaid;

        }


        private void UpdateDueBalance(MonthlyPayment monthlyPayment)
        {
            var dueBalance = _context.dbsDueBalance
                .Where(db => db.StudentId == monthlyPayment.StudentId)
                .FirstOrDefault();

            if (dueBalance != null)
            {
                dueBalance.DueBalanceAmount = monthlyPayment.AmountRemaining;
                dueBalance.LastUpdate = DateTime.Now; // Update LastUpdate timestamp
            }
            else
            {
                _context.dbsDueBalance.Add(new DueBalance
                {
                    StudentId = monthlyPayment.StudentId,
                    DueBalanceAmount = monthlyPayment.AmountRemaining,
                    LastUpdate = DateTime.Now // Set LastUpdate timestamp for a new record
                });
            }

            _context.SaveChanges(); // Save changes to the database
        }
        //private void SaveMonthDetails(MonthlyPayment monthlyPayment)
        //{
        //    if (monthlyPayment.academicMonths != null && monthlyPayment.academicMonths.Any())
        //    {
        //        foreach (var academicMonth in monthlyPayment.academicMonths)
        //        {
        //            var paymentMonth = new PaymentMonth
        //            {
        //                PaymentId = monthlyPayment.MonthlyPaymentId,
        //                MonthName = academicMonth.MonthName
        //            };

        //            _context.paymentMonths.Add(paymentMonth);
        //        }

        //        _context.SaveChanges();
        //    }
        //}

        //private void SavePaymentDetail(MonthlyPayment monthlyPayment)
        //{
        //    if (monthlyPayment.fees != null && monthlyPayment.fees.Any())
        //    {
        //        foreach (var fees in monthlyPayment.fees)
        //        {

        //            var feesType = _context.fees
        //                .Where(ft => ft.FeeId == fees.FeeId)
        //                .FirstOrDefault();

        //            var paymentDetails = new PaymentDetail
        //            {

        //                MonthlyPaymentId=monthlyPayment.MonthlyPaymentId,
        //                FeeAmount=feesType.Amount,
        //                FeeName= feesType?.FeeName

        //            };

        //            _context.PaymentDetails.Add(paymentDetails);
        //        }

        //        _context.SaveChanges();
        //    }
        //}


        private async Task AttachFeeAsync(MonthlyPayment monthlyPayment)
        {
            if (monthlyPayment.fees != null && monthlyPayment.fees.Any())
            {
                monthlyPayment.fees = await _context.fees
                    .Where(fs => monthlyPayment.fees.Select(f => f.FeeId).Contains(fs.FeeId))
                    .ToListAsync();
            }
        }

        private async Task AttachAcademicMonthAsync(MonthlyPayment monthlyPayment)
        {
            if (monthlyPayment.academicMonths != null && monthlyPayment.academicMonths.Any())
            {
                monthlyPayment.academicMonths = await _context.dbsAcademicMonths
                    .Where(am => monthlyPayment.academicMonths.Select(m => m.MonthId).Contains(am.MonthId))
                    .ToListAsync();
            }
        }






        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMonthlyPayment(int id)
        {
            var monthlyPayment = await _context.monthlyPayments
                .Include(fp => fp.fees)
                .Include(fp => fp.academicMonths)
                .FirstOrDefaultAsync(fp => fp.MonthlyPaymentId == id);

            if (monthlyPayment == null)
            {
                return NotFound();
            }

            foreach (var academicMonth in monthlyPayment.academicMonths)
            {
                academicMonth.monthlyPayment = null;
            }

            _context.monthlyPayments.Remove(monthlyPayment);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        private bool MonthlyPaymentExists(int id)
        {
            return _context.monthlyPayments.Any(e => e.MonthlyPaymentId == id);
        }
    }
}
