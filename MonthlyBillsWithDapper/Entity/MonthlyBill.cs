using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MonthlyBillsWithDapper.Entity
{
    public class MonthlyBill
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Please enter the Bill Name")]

        [StringLength(maximumLength: 15, ErrorMessage = "Name length can't be more than 15.")]
        [Display(Name = "Bill")] 
        public string Bill { get; set; }
        [Required]


        [Range(0,99999)]
        [Display(Name = "Cost")]
        public float Cost { get; set; }


        [Required]
        [Range(0, 31)] 
        public int Date { get; set; }
        public string BillAlias { get; set; }
        public string UserID { get; set; }
        public bool Paid_ { get; set; }
    }
}
