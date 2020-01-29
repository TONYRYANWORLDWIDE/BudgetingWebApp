using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RouteHubDapperPractice.Controllers
{
    public class UpcomingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}