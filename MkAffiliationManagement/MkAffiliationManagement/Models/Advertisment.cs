using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MkAffiliationManagement.Models
{
    public class Advertisment
    {

        public int ID { get; set; }
        [Required(ErrorMessage = "Please enter a Name for your advertisment")]
        [Display(Name = "Name")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "Please endorse the product")]
        [Display(Name = "Endorsment")]
        public string ProductEndorsment { get; set; }
        [Required(ErrorMessage = "Please enter the promotional code given to you from the company sponsoring you")]
        [Display(Name = "PROMO CODE")]
        public string ProductPromotionalCode { get; set; }
        [Required(ErrorMessage = "Please enter a link to the product")]
        [Display(Name = "Link to product")]
        public string ProductLink { get; set; }
        [Required(ErrorMessage = "Please enter a VALID image link")]
        [Display(Name = "Picture")]
        public string Image { get; set; }
        [Display(Name ="Engagement - Total Clicks")]
        public int Engagements { get; set; }
        ///possible property for product rating from MK
    }
}
