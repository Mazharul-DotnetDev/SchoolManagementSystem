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

namespace SchoolApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamScheduleStandardsController : ControllerBase
    {
        private readonly SchoolDbContext _context;

        public ExamScheduleStandardsController(SchoolDbContext context)
        {
            _context = context;
        }

        // GET: api/ExamScheduleStandards
        [HttpGet]
        public async Task<IEnumerable<ExamScheduleStandardVM>> GetdbsExamScheduleStandard()
        {
            return await _context.dbsExamScheduleStandard
                .Select(it => new ExamScheduleStandardVM
                {
                    ExamScheduleName = it.ExamSchedule.ExamScheduleName,
                    ExamScheduleStandardId = it.ExamScheduleStandardId,
                    ExamScheduleId = it.ExamScheduleId,
                    StandardId = it.StandardId,
                    StandardName = it.Standard.StandardName,
                    ExamSubjects = it.ExamSubjects.Select(es => new ExamSubjectVM
                    {
                        ExamTypeId = es.ExamTypeId,
                        SubjectId = es.SubjectId,
                        ExamDate = es.ExamDate,
                        ExamEndTime = es.ExamEndTime,
                        ExamStartTime = es.ExamStartTime,
                        ExamTypeName = es.ExamType.ExamTypeName,
                        SubjectCode = es.Subject.SubjectCode,
                        SubjectName = es.Subject.SubjectName,
                    })
                })
                .AsNoTracking()
                .ToListAsync();
        }

        // GET: api/ExamScheduleStandards/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ExamScheduleStandardVM>> GetExamScheduleStandard(int id)
        {
            var examScheduleStandard = await _context.dbsExamScheduleStandard
                .Select(it => new ExamScheduleStandardVM
                {
                    ExamScheduleName = it.ExamSchedule.ExamScheduleName,
                    ExamScheduleStandardId = it.ExamScheduleStandardId,
                    ExamScheduleId = it.ExamScheduleId,
                    StandardId = it.StandardId,
                    StandardName = it.Standard.StandardName,
                    ExamSubjects = it.ExamSubjects.Select(es => new ExamSubjectVM
                    {
                        ExamTypeId = es.ExamTypeId,
                        SubjectId = es.SubjectId,
                        ExamDate = es.ExamDate,
                        ExamEndTime = es.ExamEndTime,
                        ExamStartTime = es.ExamStartTime,
                        ExamTypeName = es.ExamType.ExamTypeName,
                        SubjectCode = es.Subject.SubjectCode,
                        SubjectName = es.Subject.SubjectName,
                    })
                })
                .AsNoTracking()
                .FirstOrDefaultAsync(es => es.ExamScheduleStandardId == id);

            if (examScheduleStandard == null)
            {
                return NotFound();
            }

            return examScheduleStandard;
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutExamScheduleStandard(int id, UpdateExamScheduleStandardVM request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var existingExamScheduleStandard = await _context.dbsExamScheduleStandard
                        .Include(es => es.ExamSubjects)
                        .FirstOrDefaultAsync(es => es.ExamScheduleStandardId == id);

                    if (existingExamScheduleStandard == null)
                    {
                        return NotFound("Exam schedule standard Id not found.");
                    }

                    // Update ExamScheduleId if needed
                    if (existingExamScheduleStandard.ExamScheduleId != request.ExamScheduleId)
                    {
                        existingExamScheduleStandard.ExamScheduleId = request.ExamScheduleId;
                    }

                    // Update StandardId if needed
                    if (existingExamScheduleStandard.StandardId != request.StandardId)
                    {
                        existingExamScheduleStandard.StandardId = request.StandardId;

                        // Remove existing ExamSubjects if StandardId is changed

                        _context.dbsExamSubject.RemoveRange(existingExamScheduleStandard.ExamSubjects);
                    }

                    // Update or Add ExamSubjects
                    if (request.ExamSubjects != null)
                    {
                        foreach (var examSubject in request.ExamSubjects)
                        {
                            if (existingExamScheduleStandard.StandardId == await _context.dbsSubject
                                .Where(s => s.SubjectId == examSubject.SubjectId)
                                .Select(s => s.StandardId)
                                .SingleOrDefaultAsync())
                            {
                                DateTime.TryParse(examSubject.ExamStartTime, out DateTime startTime);
                                DateTime.TryParse(examSubject.ExamEndTime, out DateTime endTime);

                                var existingExamSubject = existingExamScheduleStandard.ExamSubjects.FirstOrDefault(es => es.SubjectId == examSubject.SubjectId);

                                if (existingExamSubject != null)
                                {

                                    existingExamSubject.ExamDate = examSubject.ExamDate;
                                    existingExamSubject.ExamStartTime = startTime;
                                    existingExamSubject.ExamEndTime = endTime;
                                    existingExamSubject.ExamTypeId = examSubject.ExamTypeId;
                                }
                                else
                                {
                                    existingExamScheduleStandard.ExamSubjects.Add(new ExamSubject
                                    {
                                        ExamDate = examSubject.ExamDate,
                                        ExamStartTime = startTime,
                                        ExamEndTime = endTime,
                                        SubjectId = examSubject.SubjectId,
                                        ExamScheduleStandardId = existingExamScheduleStandard.ExamScheduleStandardId,
                                        ExamTypeId = examSubject.ExamTypeId,
                                    });
                                }
                            }
                        }
                    }

                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();

                    return NoContent();
                }
                catch (Exception)
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            }
        }


        // POST: api/ExamScheduleStandards
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task PostExamScheduleStandard(CreateExamScheduleStandardVM request)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    if (
                            await _context.dbsExamScheduleStandard.AnyAsync(it =>
                            it.ExamScheduleId == request.ExamScheduleId &&
                            it.StandardId == request.StandardId
                            )
                        ) throw new Exception("Exam schedule standard already exist.");

                    var examScheduleStandard = new ExamScheduleStandard
                    {


                        ExamScheduleId = request.ExamScheduleId,
                        StandardId = request.StandardId
                    };

                    await _context.dbsExamScheduleStandard.AddAsync(examScheduleStandard);
                    await _context.SaveChangesAsync();

                    List<ExamSubject> examSubjects = [];
                    foreach (var examSubject in request.ExamSubjects)
                    {

                        if (request.StandardId == await _context.dbsSubject.Where(it => it.SubjectId == examSubject.SubjectId).Select(it => it.StandardId).SingleOrDefaultAsync())
                        {
                            DateTime.TryParse(examSubject.ExamStartTime, out DateTime startTime);
                            DateTime.TryParse(examSubject.ExamEndTime, out DateTime endTime);

                            examSubjects.Add(new ExamSubject
                            {
                                ExamDate = examSubject.ExamDate,
                                ExamStartTime = startTime,
                                ExamEndTime = endTime,
                                SubjectId = examSubject.SubjectId,
                                ExamScheduleStandardId = examScheduleStandard.ExamScheduleStandardId,
                                ExamTypeId = examSubject.ExamTypeId,
                            });
                        }
                    }
                    if (examSubjects.Count > 0)
                    {
                        await _context.dbsExamSubject.AddRangeAsync(examSubjects);
                        await _context.SaveChangesAsync();
                    }
                    await transaction.CommitAsync();
                }
                catch (Exception)
                {
                    //await transaction.RollbackAsync();
                    throw;
                }
            }
        }

        // DELETE: api/ExamScheduleStandards/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExamScheduleStandard(int id)
        {
            var examScheduleStandard = await _context.dbsExamScheduleStandard.Include(e => e.ExamSubjects).FirstOrDefaultAsync(e => e.ExamScheduleStandardId == id);

            if (examScheduleStandard == null)
            {
                return NotFound();
            }

            _context.dbsExamScheduleStandard.Remove(examScheduleStandard);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ExamScheduleStandardExists(int id)
        {
            return _context.dbsExamScheduleStandard.Any(e => e.ExamScheduleStandardId == id);
        }
    }
}
