using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MonthlyBillsWithDapper.Entity;
using MonthlyBillsWithDapper.Logic;
using MonthlyBillsWithDapper.Models;

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
            return View(model);
        }
    }
}