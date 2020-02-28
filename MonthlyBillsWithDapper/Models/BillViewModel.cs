using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MonthlyBillsWithDapper.Entity;


namespace MonthlyBillsWithDapper.Models
{
    public class BillsViewModel
    {

        public BillsViewModel()
        {
            TheUpcomingBills = new List<UpcomingBill>();
            MonthlyBills = new List<MonthlyBill>();
            WeeklyBills = new List<WeeklyBill>();
            bankBalance = new BankBalance();
        }

        public List<UpcomingBill> TheUpcomingBills { get; set; }
        public List<MonthlyBill> MonthlyBills { get; set; }
        public List<WeeklyBill> WeeklyBills {get;set;}
        public BankBalance bankBalance { get; set; }


    }
}