using CoreDepartment.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CoreDepartment.Controllers
{
    public class LoginController : Controller
    {
        Context _dbContext;

		public LoginController(Context dbContext)
		{
			_dbContext = dbContext;
		}

		public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {


            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Admin admin)
        {
            var infos = _dbContext.Admins.FirstOrDefault(a => a.Username == admin.Username && a.Password == admin.Password);

            if (infos != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, admin.Username)
                };
                var userIdentity = new ClaimsIdentity(claims, "Login");
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync(claimsPrincipal);

                return RedirectToAction("Index", "Personel");
            }

            return View();
        }
    }
}
