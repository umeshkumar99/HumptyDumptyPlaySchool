using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SchoolWebAPI.Controllers
{
    public class LoginController : ApiController
    {
        PlaySchoolEntities playschool = new PlaySchoolEntities();
        
        //[HttpGet]
        public List<usp_UserDetailsGet_Result> CheckLoginStatus(string username, string pwd)
        {
       List<usp_UserDetailsGet_Result>  UserDetails=   playschool.usp_UserDetailsGet(username, pwd).ToList();
            return UserDetails;
        } 
        
    }
}
