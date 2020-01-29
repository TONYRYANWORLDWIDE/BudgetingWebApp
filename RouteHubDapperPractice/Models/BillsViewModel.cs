using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RouteHubDapperPractice.Entity;


namespace RouteHubDapperPractice.Models
{
    public class BillsViewModel
    {

        public BillsViewModel()
        {
            TheUpcomingBills = new List<UpcomingBill>();
        }

        public List<UpcomingBill> TheUpcomingBills { get; set; }
    }
}

