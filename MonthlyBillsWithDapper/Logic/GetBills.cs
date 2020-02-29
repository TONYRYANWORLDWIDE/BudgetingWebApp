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

        public List<WeeklyBill> getWeeklyBills(string ASPUser)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("ASPUser", ASPUser);
            var weeklyBills = new Instance<WeeklyBill>().Execute("dbo.getWeeklyBills", parameters).ToList();
            return weeklyBills;
        }

        public List<BringHome> getBringHome(string ASPUser)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("ASPUser", ASPUser);
            var bringhome = new Instance<BringHome>().Execute("dbo.getBringHome", parameters).ToList();
            return bringhome;
        }


        public BankBalance getBankBalance(string ASPUser)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("ASPUser", ASPUser);
            var BankBalance = new Instance<BankBalance>().Execute("dbo.getBankBalance", parameters).FirstOrDefault();
            return BankBalance;
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

        public bool UpdateWeekly(WeeklyBill weeklyBill)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("id", weeklyBill.id);
            parameters.Add("Bill", weeklyBill.Bill);
            parameters.Add("Cost", weeklyBill.Cost);
            parameters.Add("DayOfWeek", weeklyBill.DayOfWeek);
            var procResponse = new Instance<dynamic>().Execute("dbo.updateweeklyBills", parameters);
            if (procResponse != null)
                return true;
            return false;
        }


        public bool DeleteMonthly(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("id", id);
            var procResponse = new Instance<dynamic>().Execute("dbo.deleteMonthlyBills", parameters);
            if (procResponse != null)
                return true;
            return false;
        }


        public bool DeleteWeekly(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("id", id);
            var procResponse = new Instance<dynamic>().Execute("dbo.deleteWeeklyBills", parameters);
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
            parameters.Add("UserID", "a5ca7194-40f8-4d8e-81ed-d56e7338317f"); // TODO use ASP User once login added

            var procResponse = new Instance<dynamic>().Execute("dbo.insertMonthlyBills", parameters);
            if (procResponse != null)
                return true;
            return false;
        }
        public bool InsertWeekly(WeeklyBill weeklyBill)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("Bill", weeklyBill.Bill);
            parameters.Add("Cost", weeklyBill.Cost);
            parameters.Add("DayOfWeek", weeklyBill.DayOfWeek);
            parameters.Add("UserID", "a5ca7194-40f8-4d8e-81ed-d56e7338317f"); // TODO use ASP User once login added
            var procResponse = new Instance<dynamic>().Execute("dbo.insertWeeklyBills", parameters);
            if (procResponse != null)
                return true;
            return false;
        }


    }
}
