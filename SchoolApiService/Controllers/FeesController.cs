using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolApp.DAL.SchoolContext;
using SchoolApp.Models.DataModels;



namespace SchoolApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeesController : ControllerBase
    {
        private readonly SchoolDbContext _context;

        public FeesController(SchoolDbContext context)
        {
            _context = context;
        }

        // GET: api/Fees
        [HttpGet]
        public async Task<ActionResult> Getfees()
        {
            try
            {
                var fees = await _context.fees

                    .Include(fp => fp.feeType)
                    .Include(fp => fp.standard)
                    .ToListAsync();

                return Ok(fees);
            }
            catch (Exception ex)
            {
                // Log the exception for debugging purposes
                Console.WriteLine($"Exception: {ex}");

                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }

        }

        // GET: api/Fees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Fee>> GetFee(int id)
        {
            var fee = await _context.fees.FindAsync(id);

            if (fee == null)
            {
                return NotFound();
            }

            return fee;
        }

        // PUT: api/Fees/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFee(int id, Fee fee)
        {
            if (id != fee.FeeId)
            {
                return BadRequest();
            }

            _context.Entry(fee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FeeExists(id))
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

        // POST: api/Fees
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Fee>> PostFee(Fee fee)
        {
            _context.fees.Add(fee);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFee", new { id = fee.FeeId }, fee);
        }

        // DELETE: api/Fees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFee(int id)
        {
            var fee = await _context.fees.FindAsync(id);
            if (fee == null)
            {
                return NotFound();
            }

            _context.fees.Remove(fee);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FeeExists(int id)
        {
            return _context.fees.Any(e => e.FeeId == id);
        }
    }
}
