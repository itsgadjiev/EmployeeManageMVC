using System.ComponentModel.DataAnnotations;
using UserManagemant.Models;

namespace UserManagemant.Database.Models
{
    public class Department
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public List<Employee> Employees { get; set; }
    }
}
