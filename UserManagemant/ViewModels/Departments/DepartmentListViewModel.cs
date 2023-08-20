using System.ComponentModel.DataAnnotations;

namespace UserManagemant.ViewModels.Departments
{
    public class DepartmentListViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
