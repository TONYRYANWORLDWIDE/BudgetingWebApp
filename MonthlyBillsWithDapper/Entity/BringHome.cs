using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MonthlyBillsWithDapper.Entity
{
    public class BringHome
    {
        public int id { get; set; }
        public string Name { get; set; }
        public Nullable<float> amount { get; set; }
        public string DayOfWeek { get; set; }
        public string Frequency { get; set; }
        [DataType(DataType.Date)]
        public DateTime? PickOnePayDate { get; set; }
        public string UserID { get; set; }
    }
}
