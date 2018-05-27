using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using PlaySchoolEntities;
using Newtonsoft.Json;
using System.Text;
using System.Configuration;

namespace HumptyDumptyPlaySchool.Areas.Login.Controllers
{
    public class UserLoginController : Controller
    {
        // GET: Login/UserLogin
        string baseaddress;
        
        PlaySchoolEntities1 playschool = new PlaySchoolEntities1();
        public UserLoginController()
        {
            baseaddress=ConfigurationManager.AppSettings["APIURL"].ToString();
        }
        public ActionResult Index()
        {

            
            return View();
        }
        
        [HttpGet]
        public async Task<JsonResult> CheckLogin(string usename,string password)
        {
            
            usp_UserDetailsGet_Result LoginInfo=new usp_UserDetailsGet_Result();
            clsLogin logindetails = new clsLogin();
            try {
                using (var client = new HttpClient())
                {
                    
                    logindetails.username = usename;
                    logindetails.pssword = password;
                    client.BaseAddress = new Uri(baseaddress);
                    string strQuery = "?username =" + usename + "&pwd =" + password;
                    //  client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    client.DefaultRequestHeaders.Clear();

                    HttpResponseMessage response = await client.PostAsJsonAsync("login/CheckLoginStatus", logindetails);
                    response.EnsureSuccessStatusCode();
                    
                    // //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                    
                    
                    //Checking the response is successful or not which is sent using HttpClient  
                    if (response.IsSuccessStatusCode)
                    {
                        //Storing the response details recieved from web api 

                         LoginInfo = await response.Content.ReadAsAsync<usp_UserDetailsGet_Result>();

                        //Deserializing the response recieved from web api and storing into the Employee list  
                      //  LoginInfo = (usp_UserDetailsGet_Result)(EmpResponse);
                        Session["LoginInfo"] = LoginInfo;

                    }
                }
             
            }
            catch (Exception ex)
            {
                throw ex;
            }

             return Json(LoginInfo,JsonRequestBehavior.AllowGet);
           // return RedirectToAction("Student/StudentDetails/StudentDetails");
        }

        [HttpGet]
        public ActionResult GetSudentDetails()
        {
            if (Session["LoginInfo"] == null)
                return View("Index");
            else
                return View();
        }
    }
}