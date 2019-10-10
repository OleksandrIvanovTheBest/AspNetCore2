using System;
using System.Collections.Generic;
using AspNetCore_Settings.Infrustructure.Middlewares;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AspNetCore_Settings.Controllers
{
    public class HomeController : Controller
    {
        private readonly UptimeService _uptimeService;
        private readonly ILogger<HomeController> _log;

        public HomeController(UptimeService uptimeService, ILogger<HomeController> log)
        {
            _uptimeService = uptimeService;
            _log = log;
        }
        public ViewResult Index(bool throwException = false)
        {
            _log.LogDebug($"Handled {Request.Path} at uptime {_uptimeService.Uptime}");
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