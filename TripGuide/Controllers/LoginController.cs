using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.Cookies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TripGuide.Models.Class;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;

namespace TripGuide.Controllers
{
    public class LoginController : Controller
    {
        Context context = new Context();
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
       
        public async Task< IActionResult> Login(Admin admin)
        {
            var information = context.Admins.FirstOrDefault(x => x.UserName == admin.UserName && x.Password == admin.Password);
            if (information !=null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, admin.UserName)
                };
                var useridentity = new ClaimsIdentity(claims, "Login");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Index","Admin");
            }

            return View();
        }
        [HttpGet]
        public async Task<IActionResult> LogOut(Admin admin)
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Login");
        }
    }
}
