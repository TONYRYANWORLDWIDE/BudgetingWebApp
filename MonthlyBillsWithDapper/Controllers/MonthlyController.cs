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

        public PartialViewResult DeleteMonthly(int id)
        {
            string ASPUser = "a5ca7194-40f8-4d8e-81ed-d56e7338317f"; 
            var mgr = new GetBills();
            mgr.DeleteMonthly(id);
            var model = new BillsViewModel();
            model.MonthlyBills = mgr.getMonthlyBills(ASPUser);
            return PartialView("_PartialMonthly", model);
        }
        [HttpPost]
        public PartialViewResult InsertMonthly(MonthlyBill monthlyBillInsert)
        {
            string ASPUser = "a5ca7194-40f8-4d8e-81ed-d56e7338317f";
            var mgr = new GetBills();
            mgr.InsertMonthly(monthlyBillInsert);
            var model = new BillsViewModel();
            model.MonthlyBills = mgr.getMonthlyBills(ASPUser);
            return PartialView("_PartialMonthly", model);
            //return true;
            //return RedirectToAction("Index");
        }


        public ActionResult getUpcoming()
        {
            string ASPUser = "a5ca7194-40f8-4d8e-81ed-d56e7338317f";
            var mgr = new GetBills();
            mgr.getUpcomingBills(ASPUser);
            return RedirectToAction("Index");
        }


        public PartialViewResult PartialMonthly()
        {
            string ASPUser = "a5ca7194-40f8-4d8e-81ed-d56e7338317f";
            var model = new BillsViewModel();
            var mgr = new GetBills();
            model.MonthlyBills = mgr.getMonthlyBills(ASPUser);
            return PartialView("_PartialMonthly", model);
        }

    }
}