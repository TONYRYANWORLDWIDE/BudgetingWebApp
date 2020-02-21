using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonthlyBillsWithDapper.Entity
{
    public class MonthlyBill
    {
        public int id { get; set; }
        public string Bill { get; set; }
        public Nullable<float> Cost { get; set; }
        public Nullable<int> Date { get; set; }
        public string BillAlias { get; set; }
        public string UserID { get; set; }
        public bool Paid_ { get; set; }
    }
}
