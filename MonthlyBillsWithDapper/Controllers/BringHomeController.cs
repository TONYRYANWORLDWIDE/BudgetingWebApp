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
    public class BringHomeController : Controller
    {
        public PartialViewResult PartialBringHome()
        {
            string ASPUser = "a5ca7194-40f8-4d8e-81ed-d56e7338317f";
            var model = new BillsViewModel();
            var bh = new BringHomeLogic();
            model.BringHomes = bh.getBringHome(ASPUser);
            return PartialView("_PartialBringHome", model);
        }

        [HttpPost]
        public PartialViewResult InsertBringHome(BringHome bringHome)
        {
            string ASPUser = "a5ca7194-40f8-4d8e-81ed-d56e7338317f";
            var mgr = new BringHomeLogic();
            mgr.InsertBringHome(bringHome);
            var model = new BillsViewModel();
            model.BringHomes = mgr.getBringHome(ASPUser);
            return PartialView("_PartialBringHome", model);
        }


        public PartialViewResult DeleteBringHome(int id)
        {
            string ASPUser = "a5ca7194-40f8-4d8e-81ed-d56e7338317f";
            var mgr = new BringHomeLogic();
            mgr.DeleteBringHome(id);
            var model = new BillsViewModel();
            model.BringHomes = mgr.getBringHome(ASPUser);
            return PartialView("_PartialBringHome", model);
        }
    }
}
