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
        //[ActionName("StudentList")] 
        public async Task<ActionResult> Index()
        {
            List<usp_StudentGet_Result> studentList = new List<usp_StudentGet_Result>();
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseUrl);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response = await client.GetAsync("Student/GetStudentList");
                    response.EnsureSuccessStatusCode();
                    if(response.IsSuccessStatusCode)
                    {

                        var studentresponse = response.Content.ReadAsStringAsync().Result;
                        studentList = JsonConvert.DeserializeObject<List<usp_StudentGet_Result>>(studentresponse);

                     

                    }
                }

            }
            catch (Exception ex)
            {
            }

            return View(studentList);
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
                HttpResponseMessage Res = client.GetAsync("Comman/GetCountries").Result;
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
                return PartialView("~/Views/Shared/_AddressPartial.cshtml", address);
                // return View(address);
            }
        }

        public JsonResult getState(int countryid)
        {
            List<SelectListItem> State = new List<SelectListItem>();
            List<usp_StateGet_Result> StateList = new List<usp_StateGet_Result>();
            //AddressModel address = new AddressModel();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = client.GetAsync("Comman/GetStateList?CountyId=" + countryid.ToString()).Result;
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    StateList = JsonConvert.DeserializeObject<List<usp_StateGet_Result>>(EmpResponse);

                }


                StateList.ForEach(x =>
                {
                    State.Add(new SelectListItem { Text = x.StateName, Value = x.StateID.ToString() });
                });
                //  return Json(State, JsonRequestBehavior.AllowGet);
                return Json(new SelectList(State, "Value", "Text", JsonRequestBehavior.AllowGet));
            }

        }

        public JsonResult getCity(int stateid)
        {

            List<usp_CitiesGet_Result> CityList = new List<usp_CitiesGet_Result>();
            List<SelectListItem> City = new List<SelectListItem>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = client.GetAsync("Comman/GetCities?StateId=" + stateid.ToString()).Result;
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    CityList = JsonConvert.DeserializeObject<List<usp_CitiesGet_Result>>(EmpResponse);


                }
                CityList.ForEach(x =>
                {
                    City.Add(new SelectListItem { Text = x.CityName, Value = x.CityID.ToString() });
                });
                //CountryList.ForEach(x => { CountryListItem.Add(new SelectListItem { Text = x.CountryName, Value = x.CountryID.ToString() }); });

            //    return Json(new SelectList(State, "Value", "Text", JsonRequestBehavior.AllowGet));
                return Json(new SelectList(City,"Value","Text", JsonRequestBehavior.AllowGet));
            }

      
        }
    }
}