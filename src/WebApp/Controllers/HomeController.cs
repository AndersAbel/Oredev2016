using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApp.Data;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _ctx;

        public HomeController(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            var userEmail = (from u in _ctx.Users
                         where u.NormalizedEmail.EndsWith("ABEL.NU")
                         select u.Email)
                         .First();

            ViewData["Message"] = userEmail;

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
