using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.IO;
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
        private readonly string path = "C:\\Users\\ceyhu\\OneDrive\\Рабочий стол\\sd\\UserManagemant\\wwwroot\\uploads\\";

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
            .Where(x => !x.IsDeleted)
            .ToList();

            return View(productViewModels);
        }

        public IActionResult DeletedIndex()
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
            .Where(x => x.IsDeleted)
            .ToList();

            return View(productViewModels);
        }


        [HttpGet("admin/employees/add")]
        public IActionResult Add()
        {
            EmployeeAddViewModel employeeAddViewModel = new EmployeeAddViewModel
            {
                Departments = _appDbContext.Departments.ToList()
            };

            return View(employeeAddViewModel);
        }

        [HttpPost("admin/employees/add")]
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
                ImageURL = employeeAddVM.Image.SaveFile(path),
                isDeleted = false

            };

            _appDbContext.Employees.Add(employee);
            _appDbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet("admin/employees/update/{userCode}")]

        public IActionResult Update(string userCode)
        {
            var updatedEmployee = _appDbContext.Employees.FirstOrDefault(x => x.UserCode == userCode);
            if (updatedEmployee is null) { return NotFound(); }

            EmployeeUpdateViewModel employeeUpdateViewModel = new EmployeeUpdateViewModel
            {
                DepartmentId = updatedEmployee.DepartmentId,
                Name = updatedEmployee.Name,
                Email = updatedEmployee.Email,
                FatherName = updatedEmployee.FatherName,
                ImageURL = updatedEmployee.ImageURL,
                PIN = updatedEmployee.PIN,
                Surname = updatedEmployee.Surname,
                Departments = _appDbContext.Departments.ToList()

            };

            return View(employeeUpdateViewModel);
        }

        [HttpPost("admin/employees/update/{userCode}")]
        public IActionResult Update(EmployeeUpdateViewModel exEmployeeUpdateViewModel)
        {
            exEmployeeUpdateViewModel.Departments = _appDbContext.Departments.ToList();
            if (!ModelState.IsValid)
                return View(exEmployeeUpdateViewModel);


            var updatedEmployee = _appDbContext.Employees.FirstOrDefault(x => x.UserCode == exEmployeeUpdateViewModel.UserCode);
            if (updatedEmployee is null) { return NotFound(); }

            string exImageUrl = updatedEmployee.ImageURL;


            updatedEmployee.Surname = exEmployeeUpdateViewModel.Surname;
            updatedEmployee.FatherName = exEmployeeUpdateViewModel.FatherName;
            updatedEmployee.Name = exEmployeeUpdateViewModel.Name;
            updatedEmployee.Email = exEmployeeUpdateViewModel.Email;    
            updatedEmployee.DepartmentId = exEmployeeUpdateViewModel.DepartmentId;
            updatedEmployee.PIN = updatedEmployee.PIN;
            updatedEmployee.UserCode = exEmployeeUpdateViewModel.UserCode;


            if (exEmployeeUpdateViewModel.Image != null)
            {
                updatedEmployee.ImageURL = exEmployeeUpdateViewModel.Image.SaveFile(path);
            }

            _appDbContext.SaveChanges();

            if (exEmployeeUpdateViewModel.Image != null && exImageUrl != null)
            {
                var prevImageUrl = path + exImageUrl;
                System.IO.File.Delete(prevImageUrl);
            }
            

            return RedirectToAction(nameof(Index));
        }



        [HttpGet("admin/employees/delete/{userCode}")]

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