using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SchoolApp.DAL.SchoolContext;
using SchoolApp.Models.DataModels;

namespace SchoolApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MarkEntriesController : ControllerBase
    {
        private readonly SchoolDbContext _context;

        public MarkEntriesController(SchoolDbContext context)
        {
            _context = context;
        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MarkEntry>>> GetdbsMarkEntry()
        {
            return await _context.dbsMarkEntry
                .Include(m => m.Staff)
                .Include(m => m.Subject)
                .Include(m => m.Marks)
                .ToListAsync();
        }

       
        [HttpGet("{id}")]
        public async Task<ActionResult<MarkEntry>> GetMarkEntry(int id)
        {
            //var markEntry = await _context.dbsMarkEntry.FindAsync(id);
            var markEntry = await _context.dbsMarkEntry
                .Include(m => m.Staff)
                .Include(m => m.Subject)
                .Include(m => m.Marks)
                .FirstOrDefaultAsync(m => m.MarkEntryId == id);


            if (markEntry == null)
            {
                return NotFound("Sorry! No MarkEntry is found. Try next time. Good luck. Nota Bene: This message is generated from the Developer");
                
            }

            return markEntry;
        }



        #region Built-In Put Method

        [HttpPut("{id}")]
        public async Task<IActionResult> PutMarkEntry(int id, MarkEntry markEntry)
        {
            if (id != markEntry.MarkEntryId)
            {
                return BadRequest();
            }

            _context.Entry(markEntry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MarkEntryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            //return NoContent();
            return Ok("MarkEntry updated successfully!");
        }

        #endregion

        #region Customized Put Method-1
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutMarkEntry(int id, MarkEntry markEntry)
        //{
        //    if (id != markEntry.MarkEntryId)
        //    {
        //        return BadRequest("Invalid request. MarkEntryId is not valid or found. ##Developer##");
        //    }

        //    var existingMarkEntry = await _context.dbsMarkEntry
        //        .Include(me => me.Marks)
        //        .FirstOrDefaultAsync(me => me.MarkEntryId == id);

        //    if (existingMarkEntry == null)
        //    {
        //        return NotFound("Mark entry not found. Invalid or Non-existong. ##Developer##");
        //    }

        //    try
        //    {
        //        // Validate and update StaffId
        //        if (markEntry.StaffId != existingMarkEntry.StaffId)
        //        {
        //            var existingStaff = await _context.dbsStaff.FindAsync(markEntry.StaffId);
        //            if (existingStaff == null)
        //            {
        //                return BadRequest("Invalid StaffId provided.");
        //            }
        //            existingMarkEntry.StaffId = markEntry.StaffId;
        //            existingMarkEntry.Staff = existingStaff;
        //        }

        //        // Validate and update SubjectId
        //        if (markEntry.SubjectId != existingMarkEntry.SubjectId)
        //        {
        //            var existingSubject = await _context.dbsSubject.FindAsync(markEntry.SubjectId);
        //            if (existingSubject == null)
        //            {
        //                return BadRequest("Invalid SubjectId provided.");
        //            }
        //            existingMarkEntry.SubjectId = markEntry.SubjectId;
        //            existingMarkEntry.Subject = existingSubject;
        //        }

        //        // Attach existing Marks to the MarkEntry
        //        var existingMarkIds = markEntry.Marks.Select(m => m.MarkId).ToList();
        //        existingMarkEntry.Marks.Clear(); // Clear existing marks to avoid conflicts
        //        existingMarkEntry.Marks = await _context.dbsMark
        //            .Where(m => existingMarkIds.Contains(m.MarkId))
        //            .ToListAsync();

        //        // Update only provided values
        //        _context.Entry(existingMarkEntry).CurrentValues.SetValues(markEntry);

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
        //    catch (DbUpdateException ex)
        //    {
        //        // Check if the exception is due to invalid StaffId/SubjectId
        //        if (ex.InnerException is SqlException sqlException && sqlException.Number == 547)
        //        {
        //            // Foreign key constraint violation, meaning invalid StaffId/SubjectId
        //            return BadRequest("Invalid StaffId/SubjectId provided.");
        //        }
        //        else
        //        {
        //            // Other database update exceptions
        //            return BadRequest("An error occurred while updating the mark entry. Please try again later.");
        //        }
        //    }

        //    return Ok("MarkEntry updated successfully!");
        //} 
        #endregion

        #region Customized Put Method-2
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutMarkEntry(int id, MarkEntry markEntry)
        //{
        //    var existingMarkEntry = await _context.dbsMarkEntry
        //                                         .Include(me => me.Subject)
        //                                         .Include(me => me.Staff)
        //                                         .Include(me => me.Marks)
        //                                         .FirstOrDefaultAsync(me => me.MarkEntryId == id);

        //    if (existingMarkEntry == null)
        //    {
        //        return NotFound("Mark entry not found.");
        //    }

        //    if (id != markEntry.MarkEntryId)
        //    {
        //        return BadRequest("Invalid ID provided.");
        //    }

        //    if (markEntry.SubjectId != 0)
        //    {
        //        var subjectExists = await _context.dbsSubject.AnyAsync(s => s.SubjectId == markEntry.SubjectId);
        //        if (!subjectExists)
        //            return BadRequest("Subject not found.");
        //    }

        //    if (markEntry.StaffId != 0)
        //    {
        //        var staffExists = await _context.dbsStaff.AnyAsync(s => s.StaffId == markEntry.StaffId);
        //        if (!staffExists)
        //            return BadRequest("Staff not found.");
        //    }

        //    if (markEntry.Marks != null && markEntry.Marks.Any())
        //    {
        //        foreach (var mark in markEntry.Marks)
        //        {
        //            var markExists = await _context.dbsMark.AnyAsync(m => m.MarkId == mark.MarkId);
        //            if (!markExists)
        //                return BadRequest($"Mark with ID {mark.MarkId} not found.");
        //        }
        //    }

        //    // Update logic moved here
        //    if (markEntry.SubjectId != 0)
        //        existingMarkEntry.SubjectId = markEntry.SubjectId;

        //    if (markEntry.StaffId != 0)
        //        existingMarkEntry.StaffId = markEntry.StaffId;

        //    if (markEntry.Marks != null && markEntry.Marks.Any())
        //    {
        //        foreach (var mark in markEntry.Marks)
        //        {
        //            if (!existingMarkEntry.Marks.Any(m => m.MarkId == mark.MarkId))
        //                existingMarkEntry.Marks.Add(mark);
        //        }
        //    }

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //        return Ok("MarkEntry updated successfully!");
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
        //} 
        #endregion



        #region Testing_PostMarkEntry
        // POST: api/MarkEntries       
        //[HttpPost]
        //public async Task<ActionResult<MarkEntry>> PostMarkEntry(MarkEntry markEntry)
        //{
        //    _context.dbsMarkEntry.Add(markEntry);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetMarkEntry", new { id = markEntry.MarkEntryId }, markEntry);
        //}


        [HttpPost]
        //public async Task<ActionResult<MarkEntry>> PostMarkEntry(MarkEntry markEntry)
        //{
        //    // Extract MarkIds from the marks array
        //    var markIds = markEntry.Marks.Select(m => m.MarkId).ToList();

        //    // Create a new MarkEntry object (optional, depending on your logic)
        //    var newMarkEntry = new MarkEntry
        //    {
        //        MarkEntryDate = markEntry.MarkEntryDate,
        //        StaffId = markEntry.StaffId,
        //        SubjectId = markEntry.SubjectId
        //    };

        //    // Retrieve existing Mark objects based on MarkIds 
        //    var existingMarks = await GetMarksByIdsAsync(markIds);

        //    // Add retrieved Mark objects to the new MarkEntry's Marks collection
        //    newMarkEntry.Marks = existingMarks;

        //    // Save the MarkEntry object
        //    _context.dbsMarkEntry.Add(newMarkEntry);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetMarkEntry", new { id = newMarkEntry.MarkEntryId }, newMarkEntry);
        //}


        //[HttpPost]
        //public async Task<ActionResult<MarkEntry>> PostMarkEntry(MarkEntry markEntry)
        //{
        //    // Check if Staff and Subject exist
        //    if (!await _context.dbsStaff.AnyAsync(s => s.StaffId == markEntry.StaffId))
        //    {
        //        return BadRequest("Invalid StaffId provided. ##DEVELOPER##");
        //    }

        //    if (!await _context.dbsSubject.AnyAsync(s => s.SubjectId == markEntry.SubjectId))
        //    {
        //        return BadRequest("Invalid SubjectId provided. ##DEVELOPER##");
        //    }

        //    // Validate MarkIds (assuming GetMarksByIdsAsync retrieves Mark objects based on IDs)
        //    var existingMarks = await GetMarksByIdsAsync(markEntry.Marks.Select(m => m.MarkId).ToList());

        //    // Check if the number of retrieved Marks matches the number of requested MarkIds
        //    if (existingMarks.Count != markEntry.Marks.Count)
        //    {
        //        return BadRequest("One or more invalid MarkIds provided. ##DEVELOPER##");
        //    }

        //    // Create a new MarkEntry object (optional, depending on your logic)
        //    var newMarkEntry = new MarkEntry
        //    {
        //        MarkEntryDate = markEntry.MarkEntryDate,
        //        StaffId = markEntry.StaffId,
        //        SubjectId = markEntry.SubjectId
        //    };

        //    // Add retrieved Mark objects to the new MarkEntry's Marks collection
        //    newMarkEntry.Marks = existingMarks;

        //    // Save the MarkEntry object
        //    _context.dbsMarkEntry.Add(newMarkEntry);
        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (Exception ex)
        //    {
        //        // Handle potential database update exceptions (optional)
        //        // You can log the exception details here for debugging purposes

        //        Debug.WriteLine(ex);
        //        return BadRequest("An error occurred while saving the mark entry. Please contact the administrator. ##Developer##");
        //    }

        //    return CreatedAtAction("GetMarkEntry", new { id = newMarkEntry.MarkEntryId }, newMarkEntry);

        //} 
        #endregion
        

        [HttpPost]
        public async Task<ActionResult<MarkEntry>> PostMarkEntry(MarkEntry markEntry)
        {
            // Check if Staff and Subject exist
            if (!await _context.dbsStaff.AnyAsync(s => s.StaffId == markEntry.StaffId))
            {
                return BadRequest("Invalid StaffId provided. ##DEVELOPER##");
            }

            if (!await _context.dbsSubject.AnyAsync(s => s.SubjectId == markEntry.SubjectId))
            {
                return BadRequest("Invalid SubjectId provided. ##DEVELOPER##");
            }

            // Validate MarkIds (assuming GetMarksByIdsAsync retrieves Mark objects based on IDs)
            var existingMarks = await GetMarksByIdsAsync(markEntry.Marks.Select(m => m.MarkId).ToList());

            // Check if the number of retrieved Marks matches the number of requested MarkIds
            if (existingMarks.Count != markEntry.Marks.Count)
            {
                return BadRequest("One or more invalid/non-existing MarkIds provided. ##DEVELOPER##");
            }

            // Create a new MarkEntry object (optional, depending on your logic)
            var newMarkEntry = new MarkEntry
            {
                MarkEntryDate = markEntry.MarkEntryDate,
                StaffId = markEntry.StaffId,
                SubjectId = markEntry.SubjectId
            };

            // Add retrieved Mark objects to the new MarkEntry's Marks collection
            newMarkEntry.Marks = existingMarks;

            // Save the MarkEntry object
            _context.dbsMarkEntry.Add(newMarkEntry);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Handle potential database update exceptions (optional)
                // You can log the exception details here for debugging purposes

                Debug.WriteLine(ex);
                return BadRequest("An error occurred while saving the mark entry. Please contact the administrator. ##Developer##");
            }

            // Now include the related Staff and Subject entities in the response
            await _context.Entry(newMarkEntry)
                .Reference(me => me.Staff)
                .LoadAsync();

            await _context.Entry(newMarkEntry)
                .Reference(me => me.Subject)
                .LoadAsync();

            return CreatedAtAction("GetMarkEntry", new { id = newMarkEntry.MarkEntryId }, newMarkEntry);
        }



        // Helper method (PostMarkEntry Method) to retrieve Marks by IDs (replace with your actual implementation)
        private async Task<List<Mark>> GetMarksByIdsAsync(List<int> markIds)
        {
            return await _context.dbsMark.Where(m => markIds.Contains(m.MarkId)).ToListAsync();
        }


        // DELETE: api/MarkEntries/5
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

            
            //return NoContent();
            return Ok($"MarkEntry with ID {id} has been successfully deleted.");
        }

        private bool MarkEntryExists(int id)
        {
            return _context.dbsMarkEntry.Any(e => e.MarkEntryId == id);
        }
    }
}
