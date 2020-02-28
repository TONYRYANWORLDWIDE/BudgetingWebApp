using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MonthlyBillsWithDapper.Entity;
using MonthlyBillsWithDapper.Logic;
using MonthlyBillsWithDapper.Models;
using Newtonsoft.Json;
namespace MonthlyBillsWithDapper.Controllers
{
    public class MonthlyController : Controller
    {
        public IActionResult Index(string ASPUser)
        {
            ASPUser = "a5ca7194-40f8-4d8e-81ed-d56e7338317f";   //testing
            var model = new BillsViewModel();
            var mgr = new GetBills();
            model.MonthlyBills = mgr.getMonthlyBills(ASPUser);
            model.WeeklyBills = mgr.getWeeklyBills(ASPUser);
            model.TheUpcomingBills = mgr.getUpcomingBills(ASPUser);
            model.bankBalance = mgr.getBankBalance(ASPUser);
            model.BringHomes = mgr.getBringHome(ASPUser);
            return View(model);
        }

        public bool UpdateMonthly(MonthlyBill monthlyBill)
        {
            var mgr = new GetBills();
            return mgr.UpdateMonthly(monthlyBill);
        }

        public bool DeleteMonthly(int id)
        {
            var mgr = new GetBills();
            return mgr.DeleteMonthly(id);
        }
        [HttpPost]
        public bool InsertMonthly(MonthlyBill monthlyBillInsert)
        {
            var mgr = new GetBills();
            mgr.InsertMonthly(monthlyBillInsert);
            return true;
            //return RedirectToAction("Index");
        }


        public ActionResult getUpcoming()
        {
            string ASPUser = "a5ca7194-40f8-4d8e-81ed-d56e7338317f";
            var mgr = new GetBills();
            mgr.getUpcomingBills(ASPUser);
            return RedirectToAction("Index");
        }

    }
}