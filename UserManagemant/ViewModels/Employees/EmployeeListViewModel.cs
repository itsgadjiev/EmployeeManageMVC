using UserManagemant.Database.Models;

namespace UserManagemant.ViewModels.Employees
{
    public class EmployeeListViewModel:BaseEmployeeViewModel
    {
        public string UserCode { get; set; }
        public string ImageURL { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public bool IsDeleted { get; set; }
    }
}
