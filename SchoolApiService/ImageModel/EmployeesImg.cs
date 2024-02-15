using SchoolApp.Models.DataModels;

namespace SchoolApiService.ImageModel
{
    public class EmployeesImg : Employee
    {
        public IFormFile? file { get; set; }
    }
}
