using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolApp.DAL.SchoolContext;
using SchoolApp.Models.DataModels;


namespace SchoolApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommonController : ControllerBase
    {
        private readonly SchoolDbContext _context;

        public CommonController(SchoolDbContext context)
        {
            _context = context;
        }

        // GET: api/Common/Frequency
        [HttpGet("Frequency")]
        public ActionResult<string[]> GetFrequency()
        {
            // Retrieve the enum values
            string[] frequencies = Enum.GetNames(typeof(Frequency));
            return Ok(frequencies);
        }

        [HttpGet("GetAllPaymentByStudentId/{studentId}")]
        public async Task<ActionResult<IEnumerable<MonthlyPayment>>> GetAllPaymentByStudentId(int studentId)
        {
            var payments = await _context.monthlyPayments
                .Include(p => p.PaymentDetails) // Include PaymentDetails
        .Include(p => p.paymentMonths) // Include paymentMonths
        .Where(p => p.StudentId == studentId)
                .ToListAsync();

            if (payments == null || payments.Count == 0)
            {
                return NotFound();
            }

            return payments;
        }

        [HttpGet("GetAllOtherPaymentByStudentId/{studentId}")]
        public async Task<ActionResult<IEnumerable<OthersPayment>>> GetAllOtherPaymentByStudentId(int studentId)
        {
            var otherPayments = await _context.othersPayments
                .Include(p => p.otherPaymentDetails)
                .Where(p => p.StudentId == studentId)
                .ToListAsync();

            if (otherPayments == null || otherPayments.Count == 0)
            {
                return NotFound();
            }

            return otherPayments;
        }




        // GET: api/Common/DueBalances
        [HttpGet("DueBalances")]
        public async Task<ActionResult<IEnumerable<DueBalance>>> GetDueBalances()
        {
            return await _context.dbsDueBalance.ToListAsync();
        }

        // GET: api/Common/DueBalances/5
        [HttpGet("DueBalances/{id}")]
        public async Task<ActionResult<DueBalance>> GetDueBalance(int id)
        {
            var dueBalance = await _context.dbsDueBalance.FindAsync(id);

            if (dueBalance == null)
            {
                return NotFound();
            }

            return dueBalance;
        }


        //[HttpGet("GetPaymentDetailsByStudentId/{studentId}")]
        //public async Task<ActionResult<IEnumerable<object>>> GetPaymentDetailsByStudentId(int studentId)
        //{
        //    var result = await _context.PaymentDetails
        //        .Join(_context.monthlyPayments, pd => pd.MonthlyPaymentId, mp => mp.MonthlyPaymentId, (pd, mp) => new { pd, mp })
        //        .Join(_context.paymentMonths, pdmp => pdmp.mp.MonthlyPaymentId, pm => pm.MonthlyPaymentId, (pdmp, pm) => new { pdmp, pm })
        //        .Where(x => x.pdmp.mp.StudentId == studentId)
        //        .GroupBy(x => new { x.pdmp.pd.FeeName, x.pm.MonthName })
        //        .Select(group => new
        //        {
        //            FeeName = group.Key.FeeName,
        //            MonthName = group.Key.MonthName,
        //            NumberOfMonths = group.Count()
        //        })
        //        .OrderBy(entry => entry.FeeName)

        //        .ToListAsync();

        //    if (result == null || result.Count == 0)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(result);
        //}







        [HttpGet("GetPaymentDetailsByStudentId/{studentId}")]
        public async Task<ActionResult<IEnumerable<object>>> GetPaymentDetailsByStudentId(int studentId)
        {
            var result = await _context.PaymentDetails
                .Join(_context.monthlyPayments, pd => pd.MonthlyPaymentId, mp => mp.MonthlyPaymentId, (pd, mp) => new { pd, mp })
                .Join(_context.paymentMonths, pdmp => pdmp.mp.MonthlyPaymentId, pm => pm.MonthlyPaymentId, (pdmp, pm) => new { pdmp, pm })
                .Where(x => x.pdmp.mp.StudentId == studentId)
                .GroupBy(x => new { x.pdmp.pd.FeeName })
                .Select(group => new
                {
                    FeeName = group.Key.FeeName,
                    Months = group.Select(g => g.pm.MonthName).Distinct().ToList(),
                    NumberOfMonths = group.Count()
                })
                .OrderBy(entry => entry.FeeName)
                .ToListAsync();

            if (result == null || result.Count == 0)
            {
                return NotFound();
            }

            return Ok(result);
        }












    }
}
