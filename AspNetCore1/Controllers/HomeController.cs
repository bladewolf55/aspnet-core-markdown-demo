using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace AspNetCore1.Controllers
{
    public class HomeController: Controller
    {
        private readonly IClock _clock;
        public HomeController(IClock clock)
        {
            _clock = clock;

        }

        //Including this only to demo. The app would work fine using a static file.
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = $"It is {_clock.GetTime().ToString("T")}";
            return View();
        }
    }
}
