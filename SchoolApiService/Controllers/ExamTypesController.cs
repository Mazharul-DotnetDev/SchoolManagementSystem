using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolApp.DAL.SchoolContext;
using SchoolApp.Models.DataModels;
//using SchoolApp.Models.ViewModels;

namespace SchoolApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamTypesController : ControllerBase
    {
        private readonly SchoolDbContext _context;

        public ExamTypesController(SchoolDbContext context)
        {
            _context = context;
        }

        // GET: api/ExamTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExamType>>> GetdbsExamType()
        {
            return await _context.dbsExamType.ToListAsync();
        }

        // GET: api/ExamTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ExamType>> GetExamType(int id)
        {
            var examType = await _context.dbsExamType.FindAsync(id);

            if (examType == null)
            {
                return NotFound();
            }

            return examType;
        }

        // PUT: api/ExamTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExamType(int id, ExamType examType)
        {
            if (id != examType.ExamTypeId)
            {
                return BadRequest();
            }

            _context.Entry(examType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExamTypeExists(id))
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

        // POST: api/ExamTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ExamType>> PostExamType(ExamType examType)
        {
            _context.dbsExamType.Add(examType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExamType", new { id = examType.ExamTypeId }, examType);
        }

        // DELETE: api/ExamTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExamType(int id)
        {
            var examType = await _context.dbsExamType.FindAsync(id);
            if (examType == null)
            {
                return NotFound();
            }

            _context.dbsExamType.Remove(examType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ExamTypeExists(int id)
        {
            return _context.dbsExamType.Any(e => e.ExamTypeId == id);
        }
    }
}
