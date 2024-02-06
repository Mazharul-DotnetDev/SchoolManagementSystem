using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolApiService.ImageHandle;
using SchoolApp.DAL.SchoolContext;
using SchoolApp.Models.DataModels;
using static NuGet.Packaging.PackagingConstants;

namespace SchoolApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize()]
    public class EmployeesController : ControllerBase
    {
        private readonly SchoolDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public EmployeesController(SchoolDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }


        //Asynchronously uploads an employee image to the "Upload" folder and sets the image path on the EmployeesImg object.
        private async Task<string> UploadImage(EmployeesImg empPic)
        {
            string imagepath = "\\Upload\\" + empPic.file.FileName;


            string filepath = _hostEnvironment.WebRootPath + imagepath;

            using (FileStream filestream = System.IO.File.Create(filepath))
            {
                await empPic.file.CopyToAsync(filestream);
                await filestream.FlushAsync();
                //  return "\\Upload\\" + objFile.files.FileName;
            }

            empPic.ImagePath = imagepath;
            return imagepath;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetdbsEmployee()
        {
            return await _context.dbsEmployee.Include(e => e.EmployeeType).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var employee = await _context.dbsEmployee
              .Include(e => e.EmployeeType)
              .FirstOrDefaultAsync(e => e.EmployeeId == id);

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id, EmployeesImg empPic)
        {
            if (id != empPic.EmployeeId)
            {
                return BadRequest();
            }

            if (empPic.file != null)
            {
                try
                {
                    empPic.ImagePath = await UploadImage(empPic);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            _context.Entry(empPic).State = EntityState.Modified;


            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
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


        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(EmployeesImg empPic)
        {
            if (empPic.file != null)
            {
                try
                {
                    empPic.ImagePath = await UploadImage(empPic);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }

            _context.Attach(empPic);

            _context.Entry(empPic).Reference(e => e.EmployeeType).Load();

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployee", new { id = empPic.EmployeeId }, empPic);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = await _context.dbsEmployee.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            _context.dbsEmployee.Remove(employee);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeeExists(int id)
        {
            return _context.dbsEmployee.Any(e => e.EmployeeId == id);
        }
    }
}
