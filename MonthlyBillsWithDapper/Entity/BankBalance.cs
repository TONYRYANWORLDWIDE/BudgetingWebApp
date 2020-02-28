using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonthlyBillsWithDapper.Entity
{
    public class BankBalance
    {
        public int id { get; set; }
        public Nullable<float> KeyBalance { get; set; }
        public Nullable<System.DateTime> DateTime { get; set; }
        public Nullable<float> AvailableBalance { get; set; }

    }
}
