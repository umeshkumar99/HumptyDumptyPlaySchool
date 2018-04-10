using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PlaySchoolEntities;


namespace SchoolAPI.Controllers
{
    public class StudentController : ApiController
    {

        PlaySchoolEntities1 playschool = new PlaySchoolEntities1();

        [HttpGet]
        public List<usp_StudentGet_Result> GetStudentList()
        {
            //   string username = "admin"; string pwd = "123456";
            //List<usp_UserDetailsGet_Result> UserDetails = playschool.usp_UserDetailsGet(username, pwd).ToList();
            List<usp_StudentGet_Result> StudentDetails = playschool.usp_StudentGet().ToList();
            return StudentDetails;
        }


    }
}
