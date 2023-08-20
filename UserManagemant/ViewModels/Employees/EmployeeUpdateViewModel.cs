using UserManagemant.Database.Models;

namespace UserManagemant.ViewModels.Employees
{
    public class EmployeeUpdateViewModel : BaseEmployeeViewModel
    {
        public string UserCode { get; set; }
        public IFormFile Image { get; set; }
        public string ImageURL { get; set; }
        public int DepartmentId { get; set; }
        public List<Department> Departments { get; set; }
        public bool isDeleted { get; set; }


    }
}
