using CoreDepartment.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CoreDepartment.Controllers
{
    public class PersonelController : Controller
    {
        Context _dbContext;

        public PersonelController(Context dbContext)
        {
            _dbContext = dbContext;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var list =await _dbContext.Personels.Include(p => p.Department).ToListAsync();

            return View(list);
        }

        public IActionResult AddPersonel()
        {
            List<SelectListItem> values = (from p in _dbContext.Departments.ToList()
                                           select new SelectListItem
                                           {
                                               Text = p.DepartmentName,
                                               Value = p.Id.ToString()
                                           }).ToList();

            ViewBag.Values = values;

            ViewBag.deneme = _dbContext.Departments.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult AddPersonel(Personel personel)
        {
            var per = _dbContext.Departments.Where(d => d.Id == personel.Department.Id).FirstOrDefault();
            personel.Department = per;

            _dbContext.Personels.Add(personel);
            _dbContext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
