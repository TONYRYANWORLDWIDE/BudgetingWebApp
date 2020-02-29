using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonthlyBillsWithDapper.Entity
{
    public class WeeklyBill
    {
        public string Bill { get; set; }
        public float Cost { get; set; }
        public int id { get; set; }
        public string DayOfWeek { get; set; }
        public string UserID { get; set; }


    }
}
