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
    public class MonthlyController : Controller
    {
        public IActionResult Index()
        {
            string ASPUser = GetUserId();   //testing
            var model = new BillsViewModel();
            var mgr = new GetBills();
            var bh = new BringHomeLogic();
            model.MonthlyBills = mgr.getMonthlyBills(ASPUser);
            model.WeeklyBills = mgr.getWeeklyBills(ASPUser);
            model.TheUpcomingBills = mgr.getUpcomingBills(ASPUser);
            model.bankBalance = mgr.getBankBalance(ASPUser);
            model.BringHomes = bh.getBringHome(ASPUser);
            return View(model);
        }

        public PartialViewResult UpdateMonthly(MonthlyBill monthlyBill)
        {
            string ASPUser = GetUserId();
            var mgr = new GetBills();
            mgr.UpdateMonthly(monthlyBill);
            var model = new BillsViewModel();
            model.MonthlyBills = mgr.getMonthlyBills(ASPUser);
            return PartialView("_PartialMonthly", model);
        }

        public PartialViewResult UpdateWeekly(WeeklyBill weeklyBill)
        {
            string ASPUser = "a5ca7194-40f8-4d8e-81ed-d56e7338317f";
            var mgr = new GetBills();
            mgr.UpdateWeekly(weeklyBill);
            var model = new BillsViewModel();
            model.WeeklyBills = mgr.getWeeklyBills(ASPUser);
            return PartialView("_PartialWeekly", model);
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

        public PartialViewResult Deleteweekly(int id)
        {
            string ASPUser = "a5ca7194-40f8-4d8e-81ed-d56e7338317f";
            var mgr = new GetBills();
            mgr.DeleteWeekly(id);
            var model = new BillsViewModel();
            model.WeeklyBills = mgr.getWeeklyBills(ASPUser);
            return PartialView("_PartialWeekly", model);
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
        }

        [HttpPost]
        public PartialViewResult InsertWeekly(WeeklyBill weeklyBillInsert)
        {
            string ASPUser = "a5ca7194-40f8-4d8e-81ed-d56e7338317f";
            var mgr = new GetBills();
            mgr.InsertWeekly(weeklyBillInsert);
            var model = new BillsViewModel();
            model.WeeklyBills = mgr.getWeeklyBills(ASPUser);
            return PartialView("_PartialWeekly", model);
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

        public PartialViewResult PartialWeekly()
        {
            string ASPUser = "a5ca7194-40f8-4d8e-81ed-d56e7338317f";
            var model = new BillsViewModel();
            var mgr = new GetBills();
            model.WeeklyBills = mgr.getWeeklyBills(ASPUser);
            return PartialView("_PartialWeekly", model);
        }



    }
}