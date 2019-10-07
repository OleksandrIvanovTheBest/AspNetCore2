using System;
using System.Collections.Generic;
using AspNetCore_Settings.Infrustructure.Middlewares;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore_Settings.Controllers
{
    public class HomeController : Controller
    {
        private readonly UptimeService _uptimeService;

        public HomeController(UptimeService uptimeService)
        {
            _uptimeService = uptimeService;
        }
        public IActionResult Index(bool throwException = false)
        {
            if (throwException)
            {
                throw new NullReferenceException();
            }
            return View(new Dictionary<string, string>
            {
                ["Message"] = "This is the Index action",
                ["Uptime"] = $"{_uptimeService.Uptime}ms"
            });
        }

        public ViewResult Error() =>
            View(
                nameof(Index),
                new Dictionary<string, string>
                {
                    ["Message"] = "This is the Error action"
                }
            );
    }
}