using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HumptyDumptyPlaySchool.Areas.Comman.Controllers;
using HumptyDumptyPlaySchool.Models;
using System.Configuration;
using System.Threading.Tasks;
using System.Net.Http;
using PlaySchoolEntities;
using System.Net.Http.Headers;

using Newtonsoft.Json;

namespace HumptyDumptyPlaySchool.Areas.Student.Controllers
{
    public class StudentDetailsController : Controller
    {
         CommanController clscomman;
        string baseUrl;
        public StudentDetailsController()
        {
            baseUrl = ConfigurationManager.AppSettings["APIURL"].ToString();
        }
        // GET: Student/StudentDetails
        [ActionName("StudentDetails")]
        public ActionResult Index()
        {
           
            return View();
        }
        [ChildActionOnly]


        public ActionResult GetCountries()
        {
            List<usp_CountryGet_Result> CountryList = new List<usp_CountryGet_Result>();
            List<SelectListItem> CountryListItem = new List<SelectListItem>();
            AddressModel address = new AddressModel();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res =  client.GetAsync("Comman/GetCountries").Result;
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    CountryList = JsonConvert.DeserializeObject<List<usp_CountryGet_Result>>(EmpResponse);


                }
                CountryList.ForEach(x => { CountryListItem.Add(new SelectListItem { Text = x.CountryName, Value = x.CountryID.ToString() }); });
                address.CountryName = CountryListItem;
             //   return Json(CountryList, JsonRequestBehavior.AllowGet);
                return PartialView( "~/Views/Shared/_AddressPartial.cshtml", address);
                // return View(address);
            }


        }



        //public ActionResult AddressDetails()
        //{
        //    clscomman.GetCountries();
        //    List<SelectListItem> CountryListItem = new List<SelectListItem>();
        //    AddressModel address = new AddressModel();
        //    CountryList.ForEach(x => { CountryListItem.Add(new SelectListItem { Text = x.CountryName, Value = x.CountryID.ToString() })});
        //    address.CountryName = CountryListItem;
        //    return Json(CountryList, JsonRequestBehavior.AllowGet);
        //    // return View(address);
        //    return PartialView("~/Views/Shared/_AddressPartial.cshtml", address);
        //}
    }
}