using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace HumptyDumptyPlaySchool.Models
{
    public class AddressModel
    {
        [Required]
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string LandMark;
        //public IList<SelectListItem> CountryName { get; set; }
        //public IList<SelectListItem> StateName { get; set; }
        //public IList<SelectListItem> CityName { get; set; }
        [Required]
        public string CountryName { get; set; }
        
        public int CountryID { get; set; }
        public int StateId { get; set; }
        [Required]
        public string StateName { get; set; }
        [Required]
        public string CityName { get; set; }
        [Required]
        public string Zipcode { get; set; }

    }
}