using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RouteHubDapperPractice.Entity;
using static RouteHubDapperPractice.Data.DataAccess;


namespace RouteHubDapperPractice.Logic
{
    public class GetUpcomingBills
    {
        public List<UpcomingBill> getUpcomingBills(string ASPUser)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("ASPUser", ASPUser);

            var upcomingBills = new Instance<UpcomingBill>().Execute("dbo.getUpcomingBills", parameters).ToList();
            return upcomingBills;
        }
    }
}
