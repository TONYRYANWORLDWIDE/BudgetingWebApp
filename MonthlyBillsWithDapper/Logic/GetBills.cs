using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MonthlyBillsWithDapper.Entity;
using static MonthlyBillsWithDapper.Data.DataAccess;


namespace MonthlyBillsWithDapper.Logic
{
    public class GetBills
    {
        public List<UpcomingBill> getUpcomingBills(string ASPUser)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("ASPUser", ASPUser);
            var upcomingBills = new Instance<UpcomingBill>().Execute("dbo.getUpcomingBills", parameters).ToList();
            return upcomingBills;
        }
        public List<MonthlyBill> getMonthlyBills(string ASPUser)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("ASPUser", ASPUser);
            var monthlyBills = new Instance<MonthlyBill>().Execute("dbo.getMonthlyBills", parameters).ToList();
            return monthlyBills;
        }
    }
}
