using UserManagemant.Validations;

namespace UserManagemant.ViewModels.Employees
{
    public class BaseEmployeeViewModel 
    {
        [MinMaxStringLength(3, 20)]
        public string Name { get; set; }
        [MinMaxStringLength(3, 20)]
        public string Surname { get; set; }
        [MinMaxStringLength(3, 20)]
        public string FatherName { get; set; }
        [PINValidation]
        public string PIN { get; set; }
        [EmailValidation]
        public string Email { get; set; }
    }
}
