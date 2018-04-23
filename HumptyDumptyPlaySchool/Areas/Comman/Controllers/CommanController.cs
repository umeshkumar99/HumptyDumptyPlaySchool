using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.Threading.Tasks;
using System.Net.Http;
using PlaySchoolEntities;
using System.Net.Http.Headers;
using HumptyDumptyPlaySchool.Models;
using Newtonsoft.Json;

namespace HumptyDumptyPlaySchool.Areas.Comman.Controllers
{
    public class CommanController : Controller
    {
        string baseUrl;
        public CommanController()
        {
            baseUrl = ConfigurationManager.AppSettings["APIURL"].ToString();
        }
        // GET: Comman/Comman
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        //to get Countrylist 
        public async Task<ActionResult> GetCountries()
        {
            List<usp_CountryGet_Result> CountryList = new List<usp_CountryGet_Result>();
           //List<SelectListItem> CountryListItem = new List<SelectListItem>();
           // AddressModel  address=new AddressModel();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync(" Comman/GetCountries");
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    CountryList = JsonConvert.DeserializeObject<List<usp_CountryGet_Result>>(EmpResponse);
                   

                }
                //CountryList.ForEach(x=> { CountryListItem.Add(new SelectListItem { Text=x.CountryName,Value=x.CountryID.ToString()})});
                //address.CountryName = CountryListItem;
                return Json(CountryList, JsonRequestBehavior.AllowGet);
                // return View(address);
            }


        }



        //to get state list
        [HttpGet]
        public async Task<ActionResult> GetStates(int CountryID)
        {
            List<usp_StateGet_Result> StateList = new List<usp_StateGet_Result>();
            AddressModel address = new AddressModel();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("Comman/GetStateList?CountyId=" + CountryID.ToString());
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    StateList = JsonConvert.DeserializeObject<List<usp_StateGet_Result>>(EmpResponse);


                }
                return Json(StateList, JsonRequestBehavior.AllowGet);
            }


        }

        [HttpGet]
        public async Task<ActionResult> GetCities(int Stateid)
        {
            List<usp_CitiesGet_Result> CityList = new List<usp_CitiesGet_Result>();
            AddressModel address = new AddressModel();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("Comman/GetCities?StateId=" + Stateid.ToString());
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    CityList = JsonConvert.DeserializeObject<List<usp_CitiesGet_Result>>(EmpResponse);


                }
              
                return Json(CityList, JsonRequestBehavior.AllowGet);
            }


        }
        [HttpGet]
        public JsonResult GetMasterList(string MasterCode)
        {
            List<usp_MasterGetList_Result> MasterList = new List<usp_MasterGetList_Result>();
         //   AddressModel address = new AddressModel();
            List<SelectListItem> Master = new List<SelectListItem>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res =  client.GetAsync("Comman/GetMasterData?MasterCode=" + MasterCode).Result;
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var MasterResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Mater list  
                    MasterList = JsonConvert.DeserializeObject<List<usp_MasterGetList_Result>>(MasterResponse);


                }
                MasterList.ForEach(x =>
                {
                    Master.Add(new SelectListItem { Text = x.MasterValue, Value = x.MasterCodeID.ToString() });
                });
                return Json(new SelectList(Master, "Value", "Text",JsonRequestBehavior.AllowGet));
            }


        }
    }
}