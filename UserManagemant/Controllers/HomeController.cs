using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UserManagemant.Database;
using UserManagemant.Database.Models;
using UserManagemant.Models;
using UserManagemant.Services;
using UserManagemant.ViewModels.Employees;

namespace UserManagemant.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly UserCode _userCode;

        public HomeController()
        {
            _appDbContext = new AppDbContext();
            _userCode = new UserCode();
        }
        public IActionResult Index()
        {

            var productViewModels = _appDbContext.Employees
            .Select(e => new EmployeeListViewModel
            {
                Email = e.Email,
                Department = e.Department,
                DepartmentId = e.DepartmentId,
                FatherName = e.FatherName,
                ImageURL = e.ImageURL,
                Name = e.Name,
                PIN = e.PIN,
                Surname = e.Surname,
                UserCode = e.UserCode,
                IsDeleted = e.isDeleted
            })
            .OrderBy(x => x.IsDeleted)
            .ToList();

            return View(productViewModels);
        }

        [HttpGet]
        public IActionResult Add()
        {
            EmployeeAddViewModel employeeAddViewModel = new EmployeeAddViewModel
            {
                Departments = _appDbContext.Departments.ToList()
            };

            return View(employeeAddViewModel);
        }

        [HttpPost]
        public IActionResult Add(EmployeeAddViewModel employeeAddVM)
        {
            if (!ModelState.IsValid) { return View(employeeAddVM); }

            Employee employee = new Employee
            {
                Email = employeeAddVM.Email,
                DepartmentId = employeeAddVM.DepartmentId,
                FatherName = employeeAddVM.FatherName,
                Name = employeeAddVM.Name,
                PIN = employeeAddVM.PIN,
                Surname = employeeAddVM.Surname,
                UserCode = _userCode.GenarateAndReturnUniqueUserCode(),
                ImageURL = employeeAddVM.Image.SaveFile("C:\\Users\\ceyhu\\OneDrive\\Рабочий стол\\sd\\UserManagemant\\wwwroot\\uploads\\"),
                isDeleted = false

            };

            _appDbContext.Employees.Add(employee);
            _appDbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(string userCode)
        {
            var deletedEmployee = _appDbContext.Employees.FirstOrDefault(x => x.UserCode == userCode);
            if (deletedEmployee is null) { return NotFound(); }

            deletedEmployee.isDeleted = true;
            _appDbContext.SaveChanges();

            return RedirectToAction(nameof(Index));

        }





    }
}