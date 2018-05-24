using System;
using System.Collections.Generic;
using System.Web.Mvc;
using HumptyDumptyPlaySchool.Areas.Comman.Controllers;
using HumptyDumptyPlaySchool.Models;
using System.Configuration;
using System.Threading.Tasks;
using System.Net.Http;
using PlaySchoolEntities;
using System.Net.Http.Headers;
using System.IO;
using Newtonsoft.Json;
using System.Web;

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
            if (Session["LoginInfo"] != null)
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
                        if (response.IsSuccessStatusCode)
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
            else
                return RedirectToAction("Index", "UserLogin",new { area="Login"});
                    //View("/Login/UserLogin/Index");
        }

        [HttpGet]
        public ActionResult CreateStudent ()
        {
            if (Session["LoginInfo"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "UserLogin", new { area = "Login" });
            }
        }
        [HttpPost]
        public async Task< ActionResult> CreateStudent(usp_StudentbyIDGet_Result student)
        {
            try
            {
                if (Session["LoginInfo"] != null)
                {
                    if (ModelState.IsValid)
                    {
                        // usp_StudentbyIDGet_Result studentdetails = new usp_StudentbyIDGet_Result();
                        string studentphoto = string.Empty, fatherphoto = string.Empty, motherphoto = string.Empty;
                        //studentdetails.StudentName = student.StudentName.ToString();
                        student.StateID = Convert.ToInt32(Request.Form["State"].ToString());
                        student.CountryID = Convert.ToInt32(Request.Form["CountryName"].ToString());
                        student.CityID = Convert.ToInt32(Request.Form["City"].ToString());
                        student.GenderId = Convert.ToInt32(Request.Form["Gender"].ToString());
                        student.MotherOccupationId = Convert.ToInt32(Request.Form["MotherOccupation"].ToString());
                        student.FatherOccupationId = Convert.ToInt32(Request.Form["City"].ToString());
                        student.StudentSourceId = Convert.ToInt32(Request.Form["StudentSource"].ToString());
                        var fp = Request.Files["studentphoto"];

                        if (fp != null && fp.ContentLength >= 0)
                        {
                            var fileName = Path.GetFileName(fp.FileName);
                            Guid Id = Guid.NewGuid();
                            studentphoto = "~/App_Data/Upload/" + Id.ToString() + Path.GetExtension(fileName);
                            string path = Server.MapPath("~/App_Data/Upload/") + Id.ToString() + Path.GetExtension(fileName);
                            fp.SaveAs(path);
                            fp = null;
                        }
                        fp = Request.Files["fatherphoto"];
                        if (fp != null && fp.ContentLength >= 0)
                        {
                            var fileName = Path.GetFileName(fp.FileName);
                            Guid Id = Guid.NewGuid();
                            fatherphoto = "~/App_Data/Upload/" + Id.ToString() + Path.GetExtension(fileName);
                            string path = Server.MapPath("~/App_Data/Upload/") + Id.ToString() + Path.GetExtension(fileName);
                            fp.SaveAs(path);
                            fp = null;
                        }
                        fp = Request.Files["motherphoto"];
                        if (fp != null && fp.ContentLength >= 0)
                        {
                            var fileName = Path.GetFileName(fp.FileName);
                            Guid Id = Guid.NewGuid();
                            motherphoto = "~/App_Data/Upload/" + Id.ToString() + Path.GetExtension(fileName);
                            string path = Server.MapPath("~/App_Data/Upload/") + Id.ToString() + Path.GetExtension(fileName);
                            fp.SaveAs(path);
                            fp = null;
                        }
                        student.MotherPhoto = motherphoto.ToString();
                        student.FatherPhoto = fatherphoto.ToString();
                        student.StudentPhoto = studentphoto.ToString();
                        usp_UserDetailsGet_Result userdetails = (usp_UserDetailsGet_Result)Session["LoginInfo"];
                        student.UserID = userdetails.UserID;
                        using (var client = new HttpClient())
                        {
                            client.BaseAddress = new Uri(baseUrl);
                            client.DefaultRequestHeaders.Clear();
                            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                            HttpResponseMessage response = await client.PostAsJsonAsync("Student/SudentInsert", student);
                            response.EnsureSuccessStatusCode();
                            if (response.IsSuccessStatusCode)
                            {

                                var studentresponse = response.Content.ReadAsStringAsync().Result;
                                //  studentList = JsonConvert.DeserializeObject<List<usp_StudentGet_Result>>(studentresponse);

                            }
                        }
                    }
                    else
                        RedirectToAction("CreateStudent");

                }
                else
                {
                    return RedirectToAction("Index", "UserLogin", new { area = "Login" });
                }
            }
            catch(Exception ex)
            {

            }
            //List<FileDetail> fileDetails = new List<FileDetail>();
            //for (int i = 0; i < Request.Files.Count; i++)
            //{
            //    var file = Request.Files[i];


            //    if (file != null && file.ContentLength >= 0)
            //    {
            //        var fileName = Path.GetFileName(file.FileName);

            //    Guid Id = Guid.NewGuid();

            //    string path = Server.MapPath("~/App_Data/Upload/") + Id.ToString()  + Path.GetExtension(fileName);
            //        file.SaveAs(path);
            //    }
            //}

            return RedirectToAction("Index");

        }

        [HttpGet]
        public async Task<ActionResult> EditStudent(int? id)
        {
            if (Session["LoginInfo"] != null)
            {
                //if (id != null)
                //{
                List<usp_StudentbyIDGet_Result> studentList = new List<usp_StudentbyIDGet_Result>();
                usp_StudentbyIDGet_Result studentDetail = new usp_StudentbyIDGet_Result();
                    try
                    {
                        using (var client = new HttpClient())
                        {
                            client.BaseAddress = new Uri(baseUrl);
                            client.DefaultRequestHeaders.Clear();
                            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                            HttpResponseMessage response = await client.GetAsync("Student/GetStudentByID?id=" + id.ToString());
                            response.EnsureSuccessStatusCode();
                            if (response.IsSuccessStatusCode)
                            {

                                var studentresponse = response.Content.ReadAsStringAsync().Result;
                                studentList = JsonConvert.DeserializeObject<List<usp_StudentbyIDGet_Result>>(studentresponse);
                            studentDetail = studentList.Find(student => student.StudentID == id);
                            }
                        }
                    }

                    catch (Exception ex)
                    {

                    }

                    return View(studentDetail);
              //  }
            }
            else
                return RedirectToAction("Index", "UserLogin", new { area = "Login" });
        }
        [HttpPost]
        public ActionResult EditStudent(usp_StudentGet_Result student)
        {
           
          
            return View("Index");
        }
        
        
        [ChildActionOnly]

        public ActionResult GetAddress(usp_StudentbyIDGet_Result student)
        {
            //
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
                ViewBag.CountryName = CountryListItem;
                //address.CountryName = student.CountryName;
                address.CountryID = student.CountryID;
                address.StateId = student.StateID;
                address.Address1 = student.Address1;
                address.Address2 = student.Address2;
                address.Zipcode = student.ZipCode;
                 //List<SelectListItem>(.ToString()) ;
                ViewBag.StateName = getState(student.CountryID);
                //List<SelectListItem> State = JsonConvert.DeserializeObject<List<SelectListItem>>(result); ;
                //   return Json(CountryList, JsonRequestBehavior.AllowGet);
                return PartialView("~/Views/Shared/_AddressPartialStrongly.cshtml", address);
                // return View(address);
            }
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
                ViewBag.CountryName = CountryListItem;
                //address.CountryName = CountryListItem;
                
                
                //   return Json(CountryList, JsonRequestBehavior.AllowGet);
                return PartialView("~/Views/Shared/_AddressPartial.cshtml", address);
                // return View(address);
            }
        }

        public JsonResult getState(int id)
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
                HttpResponseMessage Res = client.GetAsync("Comman/GetStateList?CountyId=" + id.ToString()).Result;
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

        public JsonResult getCity(int id)
        {

            List<usp_CitiesGet_Result> CityList = new List<usp_CitiesGet_Result>();
            List<SelectListItem> City = new List<SelectListItem>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = client.GetAsync("Comman/GetCities?StateId=" + id.ToString()).Result;
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
            
                return Json(new SelectList(City,"Value","Text", JsonRequestBehavior.AllowGet));
            }

      
        }

        public JsonResult GetMasterList(string id)
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
                HttpResponseMessage Res = client.GetAsync("Comman/GetMasterData?MasterCode=" + id).Result;
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
                return Json(new SelectList(Master, "Value", "Text", JsonRequestBehavior.AllowGet));
            }
        }
        }
    }