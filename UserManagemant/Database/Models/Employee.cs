using System.ComponentModel.DataAnnotations;
using UserManagemant.Database.Models;
using UserManagemant.Validations;

namespace UserManagemant.Models
{
    public class Employee
    {
        [Key]
        public string UserCode { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FatherName { get; set; }
        public string PIN { get; set; }
        public string Email { get; set; }
        public string ImageURL { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public bool isDeleted { get; set; } 


    }
}
