using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore_Settings.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View(new Dictionary<string, string>
            {
                ["Message"] = "This is the Index action"
            });
        }
    }
}