using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolApiService.ViewModels;
using SchoolApp.DAL.SchoolContext;
using SchoolApp.Models.DataModels;
//using SchoolApp.Models.ViewModels;

namespace SchoolApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamSchedulesController : ControllerBase
    {
        private readonly SchoolDbContext _context;

        public ExamSchedulesController(SchoolDbContext context)
        {
            _context = context;
        }

        // GET: api/ExamSchedules
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExamScheduleVM>>> GetdbsExamSchedule()
        {
            return await _context.dbsExamSchedule.
                Select(it => new ExamScheduleVM
                {
                    ExamScheduleId = it.ExamScheduleId,
                    ExamScheduleName = it.ExamScheduleName,
                    ExamScheduleStandards = it.ExamScheduleStandards.Select(ess => new ExamScheduleStandardForExamScheduleVM
                    {
                        StandardName = ess.Standard.StandardName,
                        ExamSubjects = ess.ExamSubjects.Select(es => new ExamSubjectVM
                        {
                            ExamStartTime = es.ExamStartTime,
                            ExamEndTime = es.ExamEndTime,
                            ExamDate = es.ExamDate,
                            ExamTypeName = es.ExamType.ExamTypeName,
                            SubjectName = es.Subject.SubjectName,
                            SubjectCode = es.Subject.SubjectCode
                        })

                    })

                })
                .AsNoTracking()
                .ToListAsync();
        }

        public record GetExamScheduleOptionsResponse(int ExamScheduleId, string ExamScheduleName);

        [HttpGet("GetExamScheduleOptions")]
        public async Task<IEnumerable<GetExamScheduleOptionsResponse>> GetExamScheduleOptions()
        {
            return await _context.dbsExamSchedule
                .Select(it => new GetExamScheduleOptionsResponse(it.ExamScheduleId, it.ExamScheduleName))
                .AsNoTracking()
                .ToListAsync();
        }

        // GET: api/ExamSchedules/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ExamScheduleVM>> GetExamSchedule(int id)
        {
            var examSchedule = await _context.dbsExamSchedule.
                Select(it => new ExamScheduleVM
                {
                    ExamScheduleId = it.ExamScheduleId,
                    ExamScheduleName = it.ExamScheduleName,
                    ExamScheduleStandards = it.ExamScheduleStandards.Select(ess => new ExamScheduleStandardForExamScheduleVM
                    {
                        StandardName = ess.Standard.StandardName,
                        ExamSubjects = ess.ExamSubjects.Select(es => new ExamSubjectVM
                        {
                            ExamStartTime = es.ExamStartTime,
                            ExamEndTime = es.ExamEndTime,
                            ExamDate = es.ExamDate,
                            ExamTypeName = es.ExamType.ExamTypeName,
                            SubjectName = es.Subject.SubjectName,
                            SubjectCode = es.Subject.SubjectCode
                        })

                    })

                })
                .AsNoTracking()
                .FirstOrDefaultAsync(it => it.ExamScheduleId == id);

            if (examSchedule == null)
            {
                return NotFound();
            }

            return examSchedule;
        }

        // PUT: api/ExamSchedules/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExamSchedule(int id, ExamSchedule examSchedule)
        {
            if (id != examSchedule.ExamScheduleId)
            {
                return BadRequest();
            }

            _context.Entry(examSchedule).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExamScheduleExists(id))
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

        // POST: api/ExamSchedules
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ExamSchedule>> PostExamSchedule(ExamSchedule examSchedule)
        {
            _context.dbsExamSchedule.Add(examSchedule);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExamSchedule", new { id = examSchedule.ExamScheduleId }, examSchedule);
        }


        // DELETE: api/ExamSchedules/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExamSchedule(int id)
        {
            // Find the exam schedule to be deleted
            var examSchedule = await _context.dbsExamSchedule.FindAsync(id);
            if (examSchedule == null)
            {
                return NotFound();
            }

            // Remove references from the dbsExamScheduleStandard table
            var relatedExamScheduleStandards = await _context.dbsExamScheduleStandard
                .Where(es => es.ExamScheduleId == id)
                .ToListAsync();

            foreach (var examScheduleStandard in relatedExamScheduleStandards)
            {
                // Remove the reference
                examScheduleStandard.ExamScheduleId = null;
                _context.Entry(examScheduleStandard).State = EntityState.Modified;
            }

            // Save changes to apply the removal of references
            await _context.SaveChangesAsync();

            // Now, delete the exam schedule
            _context.dbsExamSchedule.Remove(examSchedule);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ExamScheduleExists(int id)
        {
            return _context.dbsExamSchedule.Any(e => e.ExamScheduleId == id);
        }
    }
}
