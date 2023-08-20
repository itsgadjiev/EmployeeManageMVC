using System.ComponentModel.DataAnnotations;

namespace UserManagemant.ViewModels.Departments
{
    public class DepartmentAddViewModel
    {
        [Required]
        public string Name { get; set; }
    }
}
