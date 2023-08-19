using UserManagemant.Database.Models;

namespace UserManagemant.ViewModels.Employees
{
    public class EmployeeListViewModel
    {
        public string UserCode { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FatherName { get; set; }
        public string PIN { get; set; }
        public string Email { get; set; }
        public string ImageURL { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public bool IsDeleted { get; set; }
    }
}
