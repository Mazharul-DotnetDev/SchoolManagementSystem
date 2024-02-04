using SchoolApp.Models.Models;

namespace SchoolApiService.ImageHandle
{
    public class EmployeesImg : Employee
    {
        public IFormFile? file { get; set; }
    }
}
