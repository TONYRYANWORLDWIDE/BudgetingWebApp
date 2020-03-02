using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MonthlyBillsWithDapper.Entity;
using static MonthlyBillsWithDapper.Data.DataAccess;

namespace MonthlyBillsWithDapper.Logic
{
    public class BringHomeLogic
    {
        public List<BringHome> getBringHome(string ASPUser)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("ASPUser", ASPUser);
            var bringhome = new Instance<BringHome>().Execute("dbo.getBringHome", parameters).ToList();
            return bringhome;
        }

        public bool InsertBringHome(BringHome bringhome, string AspUser)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("Name", bringhome.Name);
            parameters.Add("amount", bringhome.amount);
            parameters.Add("DayOfWeek", bringhome.DayOfWeek);
            parameters.Add("Frequency", bringhome.Frequency);
            parameters.Add("PickOnePayDate", bringhome.PickOnePayDate);
            parameters.Add("UserID", AspUser); // TODO use ASP User once login added

            var procResponse = new Instance<dynamic>().Execute("dbo.insertBringHome", parameters);
            if (procResponse != null)
                return true;
            return false;
        }

        public bool DeleteBringHome(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("id", id);
            var procResponse = new Instance<dynamic>().Execute("dbo.deleteBringHome", parameters);
            if (procResponse != null)
                return true;
            return false;
        }

        public bool UpdateBringHome(BringHome bringhome, string AspUser)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("id", bringhome.id);
            parameters.Add("Name", bringhome.Name);
            parameters.Add("amount", bringhome.amount);
            parameters.Add("DayOfWeek", bringhome.DayOfWeek);
            parameters.Add("Frequency", bringhome.Frequency);
            parameters.Add("PickOnePayDate", bringhome.PickOnePayDate);
            parameters.Add("UserID", AspUser); // TODO use ASP User once login added
            var procResponse = new Instance<dynamic>().Execute("dbo.updateBringHome", parameters);
            if (procResponse != null)
                return true;
            return false;
        }
    }
}
