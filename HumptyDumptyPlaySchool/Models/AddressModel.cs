using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HumptyDumptyPlaySchool.Models
{
    public class AddressModel
    {
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string LandMark;
        public IList<SelectListItem> CountryName { get; set; }
        public IList<SelectListItem> StateName { get; set; }
        public IList<SelectListItem> CityName { get; set; }
        public string Zipcode { get; set; }

    }
}