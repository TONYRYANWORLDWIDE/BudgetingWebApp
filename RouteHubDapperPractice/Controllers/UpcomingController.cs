using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RouteHubDapperPractice.Entity;
using RouteHubDapperPractice.Logic;
using RouteHubDapperPractice.Models;

namespace RouteHubDapperPractice.Controllers
{
    public class UpcomingController : Controller
    {
        public IActionResult Index(string ASPUser)
        {
            ASPUser = "a5ca7194-40f8-4d8e-81ed-d56e7338317f";   //testing
            var model = new BillsViewModel();
            var mgr = new GetUpcomingBills();
            model.TheUpcomingBills = mgr.getUpcomingBills(ASPUser);
            return View(model);
        }
    }
}