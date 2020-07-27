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
        [Required(ErrorMessage = "Please enter a name for this income stream")]

        [StringLength(maximumLength: 15, ErrorMessage = "Name length can't be more than 15.")]
        public string Name { get; set; }


        [Range(0, 9999.99)]
        //[Display(Name = "amount")]
        public float amount { get; set; }

        public string DayOfWeek { get; set; }

        public string Frequency { get; set; }

        [Required(ErrorMessage = "Please pick your most recent pay date")]
        [DataType(DataType.Date)]
        public DateTime? PickOnePayDate { get; set; }
        public string UserID { get; set; }
    }
}
