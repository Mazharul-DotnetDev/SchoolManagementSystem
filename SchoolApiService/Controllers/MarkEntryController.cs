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
    public class MarkEntryController : ControllerBase
    {
        private readonly SchoolDbContext _context;

        public MarkEntryController(SchoolDbContext context)
        {
            _context = context;
        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MarkEntry>>> GetdbsMarkEntry()
        {
            return await _context.dbsMarkEntry
                .Include(m => m.Staff)
                .Include(m => m.ExamSchedule)
                .Include(m => m.ExamType)
                .Include(m => m.Subject)
                .Include(m => m.Standard)
                .Include(m => m.StudentMarksDetails)
                .ThenInclude(m => m.Student)
                .ToListAsync();
        }

        // GET: api/MarkEntry/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MarkEntry>> GetMarkEntry(int id)
        {
            var markEntry = await _context.dbsMarkEntry
                .Include(m => m.Staff)
                .Include(m => m.ExamSchedule)
                .Include(m => m.ExamType)
                .Include(m => m.Subject)
                .Include(m => m.Standard)
                .Include(m => m.StudentMarksDetails)
                .ThenInclude(m => m.Student)
                .FirstOrDefaultAsync(m => m.MarkEntryId == id);
               
            if (markEntry == null)
            {
                return NotFound("Sorry! No Mark is found. Try next time. Good luck.");
            }

            return markEntry;
        }


        [HttpPost("GetStudents")]
        public async Task<IActionResult> GetStudents([FromBody] MarkEntry markEntry)
        {
            var students = await _context.dbsStudent.Where(s=> s.StandardId== markEntry.StandardId).ToListAsync();

            foreach (var student in students)
            {
                markEntry.StudentMarksDetails.Add(new StudentMarksDetails()
                {
                    StudentId= student.StudentId,
                    StudentName= student.StudentName,
                    //Student = student,
                });
            }
            return Ok(markEntry.StudentMarksDetails);
        }



        #region Default_Post
        //[HttpPost]
        //public async Task<ActionResult<MarkEntry>> PostMarkEntry(MarkEntry markEntry)
        //{
        //    _context.dbsMarkEntry.Add(markEntry);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetMarkEntry", new { id = markEntry.MarkEntryId }, markEntry);
        //} 
        #endregion



        [HttpPost]
        public async Task<IActionResult> CreateMarks([FromBody] MarkEntry markEntry)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                // Validate if Subject and Students are selected
                if (markEntry.SubjectId == 0)
                {
                    return BadRequest("Please select a Subject and Students for marks entry.");
                }

                //// Validate Student enrollment in the chosen Subject
                //var subject = await _context.dbsSubject.Include(s => s.Standard)
                //           .ThenInclude(std => std.Students)
                //           .Where(s => s.SubjectId == markEntry.SubjectId)
                //           .FirstOrDefaultAsync();

                //if (subject == null)
                //{
                //    return NotFound("Subject not found.");
                //}

                //// Filter Students based on enrollment in the chosen Subject 
                ////var enrolledStudents = subject.Standard?.Students.Where(s => markEntry.Students.Select(st => st.StudentId).Contains(s.StudentId));
                //var enrolledStudents = _context.dbsStudent.Where(s => s.StandardId == markEntry.Subject.StandardId);

                //// Validate if any student selected is enrolled in the Subject 
                //if (!enrolledStudents.Any())
                //{
                //    return BadRequest("Selected Students are not enrolled in the chosen Subject.");
                //}






                // Update Students collection with filtered enrolled students
                //markEntry.Students = enrolledStudents.ToList();


                await _context.dbsMarkEntry.AddAsync(markEntry);
                await _context.SaveChangesAsync();
                //await _context.dbsStudentMarksDetails.AddRangeAsync(markEntry.StudentMarksDetails);
                //await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }

            //return CreatedAtRoute("GetMarkEntry", new { id = markEntry.MarkEntryId }, markEntry);

            return CreatedAtAction("GetMarkEntry", new { id = markEntry.MarkEntryId }, markEntry);
        }


        #region Default_Put
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutMarkEntry(int id, MarkEntry markEntry)
        //{
        //    if (id != markEntry.MarkEntryId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(markEntry).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!MarkEntryExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}
        #endregion


        [HttpPut]
        public async Task<IActionResult> UpdateMarks([FromBody] MarkEntry markEntry)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Validate if Subject and Students are selected (optional for update)
            if (markEntry.SubjectId == 0 )
            {
                return BadRequest("Please select a Subject and Students for marks update.");
            }

            // Find the existing MarkEntry based on MarkEntryId (assuming it's the identifier)
            var existingMarkEntry = await _context.dbsMarkEntry
                    .Include(m => m.Subject)
                    .ThenInclude(s => s.Standard)
                    .ThenInclude(std => std.Students)
                    .Where(m => m.MarkEntryId == markEntry.MarkEntryId)
                    .FirstOrDefaultAsync();

            if (existingMarkEntry == null)
            {
                return NotFound("Mark entry not found.");
            }

            // Update relevant MarkEntry properties (excluding Students collection for now)
            existingMarkEntry.StaffId = markEntry.StaffId;
            existingMarkEntry.ExamScheduleId = markEntry.ExamScheduleId;
            existingMarkEntry.ExamTypeId = markEntry.ExamTypeId;
            existingMarkEntry.TotalMarks = markEntry.TotalMarks;
            existingMarkEntry.PassMarks = markEntry.PassMarks;
            //existingMarkEntry.ObtainedScore = markEntry.ObtainedScore;
            //existingMarkEntry.Grade = markEntry.Grade;
            //existingMarkEntry.PassStatus = markEntry.PassStatus;
            //existingMarkEntry.Feedback = markEntry.Feedback;

            //// **Validation for Student updates (if applicable):**

            //// If Students collection is provided in the request body:
            //if (markEntry.Students != null && markEntry.Students.Any())
            //{
            //    // Validate student enrollment in the chosen Subject (same logic as HttpPost)
            //    var enrolledStudents = existingMarkEntry.Subject?.Standard?.Students.Where(s => markEntry.Students.Select(st => st.StudentId).Contains(s.StudentId));

            //    // Validate if any student selected is enrolled in the Subject
            //    if (!enrolledStudents.Any())
            //    {
            //        return BadRequest("Selected Students are not enrolled in the chosen Subject.");
            //    }

            //    // **Update logic for Students collection:**

            //    // Option 1: Replace entire Students collection (consider performance for large datasets)
            //    existingMarkEntry.Students = enrolledStudents.ToList();

            //    // Option 2: Update individual student marks within the existing collection (more performant for partial updates)
            //    // This would involve iterating through markEntry.Students and updating corresponding entries in existingMarkEntry.Students
            //}

            // Save changes to the database
            await _context.SaveChangesAsync();

            // Return the updated MarkEntry object
            return Ok(existingMarkEntry);
        }




        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMarkEntry(int id)
        {
            var markEntry = await _context.dbsMarkEntry.FindAsync(id);
            if (markEntry == null)
            {
                return NotFound();
            }

            _context.dbsMarkEntry.Remove(markEntry);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MarkEntryExists(int id)
        {
            return _context.dbsMarkEntry.Any(e => e.MarkEntryId == id);
        }
    }
}
