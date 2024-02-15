using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolApp.DAL.SchoolContext;
using SchoolApp.Models.DataModels;

namespace SchoolApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeeTypesController : ControllerBase
    {
        private readonly SchoolDbContext _context;

        public FeeTypesController(SchoolDbContext context)
        {
            _context = context;
        }

        // GET: api/FeeTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FeeType>>> GetdbsFeeType()
        {
            return await _context.dbsFeeType.ToListAsync();
        }

        // GET: api/FeeTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FeeType>> GetFeeType(int id)
        {
            var feeType = await _context.dbsFeeType.FindAsync(id);

            if (feeType == null)
            {
                return NotFound();
            }

            return feeType;
        }

        // PUT: api/FeeTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFeeType(int id, FeeType feeType)
        {
            if (id != feeType.FeeTypeId)
            {
                return BadRequest();
            }

            _context.Entry(feeType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FeeTypeExists(id))
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

        // POST: api/FeeTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FeeType>> PostFeeType(FeeType feeType)
        {
            _context.dbsFeeType.Add(feeType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFeeType", new { id = feeType.FeeTypeId }, feeType);
        }

        // DELETE: api/FeeTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFeeType(int id)
        {
            var feeType = await _context.dbsFeeType.FindAsync(id);
            if (feeType == null)
            {
                return NotFound();
            }

            _context.dbsFeeType.Remove(feeType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FeeTypeExists(int id)
        {
            return _context.dbsFeeType.Any(e => e.FeeTypeId == id);
        }
    }
}
