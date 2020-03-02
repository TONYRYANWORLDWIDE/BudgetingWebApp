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
    public class BringHomeController : Controller
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


        public PartialViewResult PartialBringHome()
        {
            string ASPUser = GetUserId();
            var model = new BillsViewModel();
            var bh = new BringHomeLogic();
            model.BringHomes = bh.getBringHome(ASPUser);
            return PartialView("_PartialBringHome", model);
        }

        [HttpPost]
        public bool InsertBringHome(BringHome bringHome)
        {
            var bh = new BringHomeLogic();
            bh.InsertBringHome(bringHome);
            return true;
        }

        public bool DeleteBringHome(int id)
        {
            var bh = new BringHomeLogic();
            bh.DeleteBringHome(id);
            return true;
        }
    }
}
