using System.ComponentModel.DataAnnotations;
using UserManagemant.Database.Models;
using UserManagemant.Validations;

namespace UserManagemant.ViewModels.Employees
{
    public class EmployeeAddViewModel:BaseEmployeeViewModel
    {
        [Required]
        public IFormFile Image { get; set; }
        [Required]
        public int DepartmentId { get; set; }
        public List<Department> Departments { get; set; }

        public bool IsDeleted { get; set; }


    }
}
