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
    public class FeeStructuresController : ControllerBase
    {
        private readonly SchoolDbContext _context;

        public FeeStructuresController(SchoolDbContext context)
        {
            _context = context;
        }

        // GET: api/FeeStructures
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FeeStructure>>> GetdbsFeeStructure()
        {
            return await _context.dbsFeeStructure.ToListAsync();
        }

        // GET: api/FeeStructures/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FeeStructure>> GetFeeStructure(int id)
        {
            var feeStructure = await _context.dbsFeeStructure.FindAsync(id);

            if (feeStructure == null)
            {
                return NotFound();
            }

            return feeStructure;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFeeStructure(int id, FeeStructure updatedFeeStructure)
        {
            try
            {
                // Check if the FeeStructure with the given id exists
                FeeStructure existingFeeStructure = await _context.dbsFeeStructure.FindAsync(id);

                if (existingFeeStructure == null)
                {
                    return NotFound("FeeStructure not found");
                }

                // Update the properties of existingFeeStructure with the values from updatedFeeStructure
                existingFeeStructure.FeeTypeId = updatedFeeStructure.FeeTypeId;
                existingFeeStructure.TypeName = updatedFeeStructure.TypeName;
                existingFeeStructure.StandardId = updatedFeeStructure.StandardId;
                existingFeeStructure.StandardName = updatedFeeStructure.StandardName;
                existingFeeStructure.Monthly = updatedFeeStructure.Monthly;
                existingFeeStructure.Yearly = updatedFeeStructure.Yearly;
                existingFeeStructure.FeeAmount = updatedFeeStructure.FeeAmount;

                // Update the corresponding FeeType and Standard based on their Ids
                FeeType feeType = await _context.dbsFeeType.FindAsync(updatedFeeStructure.FeeTypeId);
                if (feeType != null)
                {
                    existingFeeStructure.TypeName = feeType.TypeName;
                }

                Standard standard = await _context.dbsStandard.FindAsync(updatedFeeStructure.StandardId);
                if (standard != null)
                {
                    existingFeeStructure.StandardName = standard.StandardName;
                }

                // Save the changes to the database
                _context.Update(existingFeeStructure);
                await _context.SaveChangesAsync();

                return Ok("FeeStructure updated successfully");
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }


        [HttpPost]
        public async Task<IActionResult> CreateFeeStructure(FeeStructure feeStructure)
        {
            try
            {
                // Assuming StandardId is the foreign key linking FeeStructure to Standard
                Standard standard = await _context.dbsStandard.FindAsync(feeStructure.StandardId);

                if (standard == null)
                {
                    return NotFound("Standard not found");
                }

                feeStructure.StandardName = standard.StandardName;

                // Assuming FeeTypeId is the foreign key linking FeeStructure to FeeType
                FeeType feeType = await _context.dbsFeeType.FindAsync(feeStructure.FeeTypeId);

                if (feeType == null)
                {
                    return NotFound("FeeType not found");
                }

                feeStructure.TypeName = feeType.TypeName;

                // Save the FeeStructure to the database
                _context.dbsFeeStructure.Add(feeStructure);
                await _context.SaveChangesAsync();

                return Ok("FeeStructure created successfully");
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }


        // DELETE: api/FeeStructures/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFeeStructure(int id)
        {
            var feeStructure = await _context.dbsFeeStructure.FindAsync(id);
            if (feeStructure == null)
            {
                return NotFound();
            }

            _context.dbsFeeStructure.Remove(feeStructure);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FeeStructureExists(int id)
        {
            return _context.dbsFeeStructure.Any(e => e.FeeStructureId == id);
        }
    }
}
