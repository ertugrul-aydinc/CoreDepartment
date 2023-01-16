using CoreDepartment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoreDepartment.Controllers
{
    public class DepartmentsController : Controller
    {
        Context _dbContext;

        public DepartmentsController(Context dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            var list =await _dbContext.Departments.ToListAsync();

            return View(list);
        }

        public IActionResult AddDepartment()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddDepartment(Department department)
        {
            await _dbContext.Departments.AddAsync(department);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public IActionResult RemoveDepartment(int id)
        {
            var deletedDepartment = _dbContext.Departments.Find(id);
            if(deletedDepartment != null)
            {
                _dbContext.Remove(deletedDepartment);
                _dbContext.SaveChanges();
            }
            
            return RedirectToAction("Index");
        }

        public IActionResult EditDepartment(int id)
        {
            var updatedDepartment = _dbContext.Departments.Find(id);
            return View(updatedDepartment);
        }
        [HttpPost]
        public IActionResult EditDepartment(Department department)
        {
            var updatedDepartment = _dbContext.Departments.Find(department.Id);

            updatedDepartment.DepartmentName = department.DepartmentName;
            _dbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult ShowDetails(int id)
        {
            var values = _dbContext.Personels.Include(p => p.Department).Where(p => p.DepartmentID == id).ToList();

            ViewBag.deneme = _dbContext.Personels.Where(p => p.Id == id).FirstOrDefault();

            return View(values);
        }
    }
}
