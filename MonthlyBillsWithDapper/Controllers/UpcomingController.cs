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

namespace MonthlyBillsWithDapper.Controllers
{
    public class UpcomingController : Controller
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
        public PartialViewResult PartialUpcoming()
        {
            string ASPUser = GetUserId();
            var model = new BillsViewModel();
            var mgr = new GetBills();
            model.TheUpcomingBills = mgr.getUpcomingBills(ASPUser);
            return PartialView("_PartialUpcoming", model);
        }


        public bool UpcomingPaid(UpcomingAlter upComingPaid)
        {
            string ASPUser = GetUserId();
            var mgr = new GetBills();
            mgr.UpdateUpcomingPaid(upComingPaid, ASPUser);
            return true;
        }
    }
}