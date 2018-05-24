using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PlaySchoolEntities;

namespace SchoolAPI.Controllers
{
    public class LoginController : ApiController
    {

        
        PlaySchoolEntities1 playschool = new PlaySchoolEntities1();

        [HttpPost]
        public usp_UserDetailsGet_Result CheckLoginStatus(clsLogin logindetails )
        {
            //   string username = "admin"; string pwd = "123456";
            //List<usp_UserDetailsGet_Result> UserDetails = playschool.usp_UserDetailsGet(username, pwd).ToList();
            //List<usp_UserDetailsGet_Result> UserDetails = playschool.usp_UserDetailsGet(logindetails.username, logindetails.pssword).FirstOrDefault();
            usp_UserDetailsGet_Result UserDetails = playschool.usp_UserDetailsGet(logindetails.username, logindetails.pssword).FirstOrDefault();
            return UserDetails;
        }

    
}
}
