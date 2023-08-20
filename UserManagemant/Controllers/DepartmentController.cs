using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserManagemant.Database;
using UserManagemant.Database.Models;
using UserManagemant.ViewModels.Departments;

namespace UserManagemant.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public DepartmentController()
        {
            _appDbContext = new AppDbContext();
        }
        #region Index

        [HttpGet]
        public IActionResult Index()
        {
            var departments = _appDbContext.Departments.ToList();
            var categoryViewModels = departments
                .Select(c => new DepartmentListViewModel
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToList();
           
            return View(categoryViewModels);
        }

        #endregion

        #region Add

        [HttpGet("add")]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost("add")]
        public IActionResult Add(DepartmentAddViewModel departmentAddViewModel)
        {
            if (!ModelState.IsValid)
                return View(departmentAddViewModel);

            Department department = new Department
            {
                Name = departmentAddViewModel.Name
            };

            _appDbContext.Departments.Add(department);
            _appDbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        #endregion

        #region Update

        [HttpGet("{id}/update")]
        public IActionResult Update(int id)
        {
            var department = _appDbContext.Departments.FirstOrDefault(c => c.Id == id);
            if (department == null) return NotFound();

            var model = new DepartmentUpdateViewModel
            {
                Id = department.Id,
                Name = department.Name
            };

            return View( model);
        }

        [HttpPost("{id}/update")]
        public IActionResult Update(DepartmentUpdateViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var department = _appDbContext.Departments.FirstOrDefault(d => d.Id == model.Id);
            if (department == null)
            {
                return NotFound();
            }

            department.Name = model.Name;
            _appDbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        #endregion

        #region Delete

        [HttpGet("{id}/delete")]
        public IActionResult Delete(int id)
        {
            var department = _appDbContext.Departments.FirstOrDefault(c => c.Id == id);
            if (department == null) return NotFound();

            _appDbContext.Departments.Remove(department);
            _appDbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        #endregion


    }
}
