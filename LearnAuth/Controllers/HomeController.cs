using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LearnAuth.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult Secret()
        {
            return View();
        }

        public IActionResult Authenticate()
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name ,"thiemdp"),
                new Claim(ClaimTypes.Email,"thiemdp.ekgis@gmail.com")
            };
            var idtt = new ClaimsIdentity(claims, "thiemdp identity");
            var userprincipal = new ClaimsPrincipal(new[] { idtt });
            HttpContext.SignInAsync(userprincipal);

           return RedirectToAction("Index");
        }
    }
}