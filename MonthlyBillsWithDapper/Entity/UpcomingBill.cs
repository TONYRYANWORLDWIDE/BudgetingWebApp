using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace MonthlyBillsWithDapper.Entity
{
    public class UpcomingBill
    {

        public int id { get; set; }
        [DataType(DataType.Date)]
        public DateTime? TheDate { get; set; }
        public string DayOfWeek { get; set; }
        public string Name { get; set; }
        public Nullable<float> Amount { get; set; }
        public string Type { get; set; }
        public Nullable<decimal> RunningTotal { get; set; }
        public string UserID { get; set; }
        public bool Paid { get; set; }
    }
}
