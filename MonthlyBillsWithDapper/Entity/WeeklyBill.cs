using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MonthlyBillsWithDapper.Entity
{
    public class WeeklyBill
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter the Bill Name")]

        [StringLength(maximumLength: 15, ErrorMessage = "Name length can't be more than 15.")]
        [Display(Name = "Bill")]
        public string Bill { get; set; }
        [Range(0, 99999)]
        [Display(Name = "Cost")] 
        public float Cost { get; set; }
        public int id { get; set; }
        public string DayOfWeek { get; set; }
        public string UserID { get; set; }


    }
}
