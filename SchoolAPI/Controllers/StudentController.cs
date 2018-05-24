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

        [HttpGet]
        public List<usp_StudentbyIDGet_Result> GetStudentByID(int id)
        {
            //   string username = "admin"; string pwd = "123456";
            //List<usp_UserDetailsGet_Result> UserDetails = playschool.usp_UserDetailsGet(username, pwd).ToList();
            List<usp_StudentbyIDGet_Result> StudentDetails = playschool.usp_StudentbyIDGet(id).ToList();
            return StudentDetails;
        }
        [HttpPost]
        public int SudentInsert(usp_StudentbyIDGet_Result studentDetails)
        {
            
           int result= playschool.usp_StudentInsert(studentDetails.StudentName, studentDetails.GenderId, studentDetails.DOB, studentDetails.DOJ, studentDetails.FatherName,
                studentDetails.FatherOccupationId, studentDetails.FatherMobileNumber, studentDetails.MotherName, studentDetails.MotherOccupationId, studentDetails.MotherMobileNumber,
                studentDetails.Address1, studentDetails.Address2, studentDetails.CityID, studentDetails.StudentPhoto, studentDetails.FatherPhoto,
                studentDetails.MotherPhoto, studentDetails.EmailId, studentDetails.Timings, studentDetails.fees, studentDetails.StudentSourceId, studentDetails.AdmissionRemarks, studentDetails.UserID) ;
            return result;
        }
    }
}
