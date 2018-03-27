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

namespace HumptyDumptyPlaySchool.Areas.Login.Controllers
{
    public class UserLoginController : Controller
    {
        // GET: Login/UserLogin
        string baseaddress= "http://localhost:30322/api/";
        PlaySchoolEntities1 playschool = new PlaySchoolEntities1();
        public ActionResult Index()
        {

                
            return View();
        }
        
        [HttpGet]
        public async Task<ActionResult> CheckLogin(string usename,string password)
        {
            try {
                using (var client = new HttpClient())
                {
                    clsLogin logindetails = new clsLogin();
                    logindetails.username = usename;
                    logindetails.pssword = password;
                    client.BaseAddress = new Uri(baseaddress);
                    string strQuery = "?username =" + usename + "&pwd =" + password;
                    //  client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    client.DefaultRequestHeaders.Clear();

                    HttpResponseMessage response = await client.PostAsJsonAsync("login/CheckLoginStatus", logindetails);
                    response.EnsureSuccessStatusCode();
                    
                    // //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                    List<usp_UserDetailsGet_Result> LoginInfo = new List<usp_UserDetailsGet_Result>();
                    
                    //Checking the response is successful or not which is sent using HttpClient  
                    if (response.IsSuccessStatusCode)
                    {
                        //Storing the response details recieved from web api   
                        var EmpResponse = response.Content.ReadAsStringAsync().Result;

                        //Deserializing the response recieved from web api and storing into the Employee list  
                        LoginInfo = JsonConvert.DeserializeObject<List<usp_UserDetailsGet_Result>>(EmpResponse);
                        Session["LoginInfo"] = LoginInfo;

                    }
                }
             
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return View();
        }
    }
}