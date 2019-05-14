using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HepsiSef.Presentation.Controllers
{
    public class RecipeController : Controller
    {

        public IActionResult SettingRecipe()
        {
            return View();
        }
        public IActionResult SettingDetailRecipe()
        {
            return View();
        }
        public IActionResult Deneme()
        {
            return View();
        }
        public IActionResult ToggleBookmark()
        {
            return View();
        }
        
    }
}
