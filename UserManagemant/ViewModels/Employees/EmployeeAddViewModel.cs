using UserManagemant.Database.Models;

namespace UserManagemant.ViewModels.Employees
{
    public class EmployeeAddViewModel
    {
        
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FatherName { get; set; }
        public string PIN { get; set; }
        public string Email { get; set; }
        public IFormFile Image { get; set; }
        public int DepartmentId { get; set; }
        public List<Department> Departments { get; set; }


    }
}
