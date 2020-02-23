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

        public bool UpdateMonthly(MonthlyBill monthlyBill)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("id", monthlyBill.id);
            parameters.Add("Bill", monthlyBill.Bill);
            parameters.Add("Cost", monthlyBill.Cost);
            parameters.Add("Date", monthlyBill.Date);
            
            var procResponse = new Instance<dynamic>().Execute("dbo.updateMonthlyBills", parameters);
            if (procResponse != null)
                return true;
            return false; 
        }

        public bool InsertMonthly(MonthlyBill monthlyBill)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("Bill", monthlyBill.Bill);
            parameters.Add("Cost", monthlyBill.Cost);
            parameters.Add("Date", monthlyBill.Date);
            var procResponse = new Instance<dynamic>().Execute("dbo.insertMonthlyBills", parameters);
            if (procResponse != null)
                return true;
            return false;
        }

    }
}
