using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MonthlyBillsWithDapper.Entity;
using MonthlyBillsWithDapper.Logic;
using MonthlyBillsWithDapper.Models;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MonthlyBillsWithDapper.Controllers
{
    public class HomeController : Controller
    {
        public string GetUserId()
        {
            string userID;
            var claimsIdentity = User.Identity as ClaimsIdentity;

            var userIdClaim = claimsIdentity.Claims
                .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
            if (userIdClaim != null)
            {
                userID = userIdClaim.Value;
            }
            else
            {
                userID = "tempuser";
            }
            return userID;

        }
        public IActionResult Index()
        {
            string ASPUser = GetUserId();  //testing
            var model = new BillsViewModel();
            var mgr = new GetBills();
            var bh = new BringHomeLogic();
            model.TheUpcomingBills = mgr.getUpcomingBills(ASPUser);
            model.bankBalance = mgr.getBankBalance(ASPUser);
            return View(model);
        }
    }
}
