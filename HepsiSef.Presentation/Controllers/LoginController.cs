using HepsiSef.Presentation.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace HepsiSef.Presentation.Controllers
{
    public class LoginController : Controller
    {
        // GET: /<controller>/
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult ForgetPassword()
        {
            return View();
        }
        public IActionResult RePassword()
        {
            var result = new ResetPasswordVM();

            if (!string.IsNullOrWhiteSpace(Request.Query["Code"]))
                result.Code = HttpUtility.UrlDecode(Request.Query["Code"]);

            return View(result);
        }

        //public IActionResult RePassword()
        //{
        //    return View();
        //}

    }
}
