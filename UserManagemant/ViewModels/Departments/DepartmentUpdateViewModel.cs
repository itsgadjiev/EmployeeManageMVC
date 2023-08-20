using System.ComponentModel.DataAnnotations;

namespace UserManagemant.ViewModels.Departments
{
    public class DepartmentUpdateViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
