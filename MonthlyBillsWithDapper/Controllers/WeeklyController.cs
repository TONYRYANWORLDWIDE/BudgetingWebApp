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
    public class WeeklyController : Controller
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
        public bool UpdateWeekly(WeeklyBill weeklyBill)
        {
            string ASPUser = GetUserId();
            var mgr = new GetBills();
            mgr.UpdateWeekly(weeklyBill);
            return true;
        }
        public PartialViewResult Deleteweekly(int id)
        {
            string ASPUser = GetUserId();
            var mgr = new GetBills();
            mgr.DeleteWeekly(id);
            var model = new BillsViewModel();
            model.WeeklyBills = mgr.getWeeklyBills(ASPUser);
            return PartialView("_PartialWeekly", model);
        }

        [HttpPost]
        public PartialViewResult InsertWeekly(WeeklyBill weeklyBillInsert)
        {
            string ASPUser = GetUserId();
            var mgr = new GetBills();
            mgr.InsertWeekly(weeklyBillInsert, ASPUser);
            var model = new BillsViewModel();
            model.WeeklyBills = mgr.getWeeklyBills(ASPUser);
            return PartialView("_PartialWeekly", model);
        }


        public PartialViewResult PartialWeekly()
        {
            string ASPUser = GetUserId();
            var model = new BillsViewModel();
            var mgr = new GetBills();
            model.WeeklyBills = mgr.getWeeklyBills(ASPUser);
            return PartialView("_PartialWeekly", model);
        }


    }
}
