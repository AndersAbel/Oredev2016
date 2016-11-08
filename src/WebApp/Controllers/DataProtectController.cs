using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.DataProtection;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class DataProtectController : Controller
    {
        IDataProtector _dataProtector;

        public DataProtectController(IDataProtectionProvider dataProtectionProvider)
        {
            _dataProtector = dataProtectionProvider.CreateProtector(nameof(DataProtectController));
        }

        public IActionResult Index()
        {
            var model = new DataProtectModel
            {
                Source = "Hello World!"
            };

            model.Protected = _dataProtector.Protect(model.Source);
            model.UnProtected = _dataProtector.Unprotect(model.Protected);
            
            return View(model);
        }
    }
}