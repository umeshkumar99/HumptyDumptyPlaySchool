﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PlaySchoolEntities
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class PlaySchoolEntities1 : DbContext
    {
        public PlaySchoolEntities1()
            : base("name=PlaySchoolEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
    
        public virtual ObjectResult<usp_UserDetailsGet_Result> usp_UserDetailsGet(string uname, string pwd)
        {
            var unameParameter = uname != null ?
                new ObjectParameter("uname", uname) :
                new ObjectParameter("uname", typeof(string));
    
            var pwdParameter = pwd != null ?
                new ObjectParameter("pwd", pwd) :
                new ObjectParameter("pwd", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<usp_UserDetailsGet_Result>("usp_UserDetailsGet", unameParameter, pwdParameter);
        }
    
        public virtual ObjectResult<usp_CitiesGet_Result> usp_CitiesGet(Nullable<int> stateid)
        {
            var stateidParameter = stateid.HasValue ?
                new ObjectParameter("stateid", stateid) :
                new ObjectParameter("stateid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<usp_CitiesGet_Result>("usp_CitiesGet", stateidParameter);
        }
    
        public virtual ObjectResult<usp_CountryGet_Result> usp_CountryGet()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<usp_CountryGet_Result>("usp_CountryGet");
        }
    
        public virtual ObjectResult<usp_StateGet_Result> usp_StateGet(Nullable<int> countryid)
        {
            var countryidParameter = countryid.HasValue ?
                new ObjectParameter("Countryid", countryid) :
                new ObjectParameter("Countryid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<usp_StateGet_Result>("usp_StateGet", countryidParameter);
        }
    
        public virtual ObjectResult<usp_MasterGetList_Result> usp_MasterGetList(string mastertype)
        {
            var mastertypeParameter = mastertype != null ?
                new ObjectParameter("mastertype", mastertype) :
                new ObjectParameter("mastertype", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<usp_MasterGetList_Result>("usp_MasterGetList", mastertypeParameter);
        }
    
        public virtual ObjectResult<usp_StudentGet_Result> usp_StudentGet()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<usp_StudentGet_Result>("usp_StudentGet");
        }
    
        public virtual int usp_StudentInsert(string studentName, Nullable<int> gender, Nullable<System.DateTime> dOB, Nullable<System.DateTime> dOJ, string fatherName, Nullable<int> fatherOccupation, string fatherMobileNumber, string motherName, Nullable<int> motherOccupation, string motherMobileNumber, string address1, string address2, Nullable<int> cityId, string studentPhoto, string fatherPhoto, string motherPhoto, string emailId, string timings, Nullable<double> fees, Nullable<int> studentSource, string admissionRemarks, Nullable<int> createdBy)
        {
            var studentNameParameter = studentName != null ?
                new ObjectParameter("StudentName", studentName) :
                new ObjectParameter("StudentName", typeof(string));
    
            var genderParameter = gender.HasValue ?
                new ObjectParameter("Gender", gender) :
                new ObjectParameter("Gender", typeof(int));
    
            var dOBParameter = dOB.HasValue ?
                new ObjectParameter("DOB", dOB) :
                new ObjectParameter("DOB", typeof(System.DateTime));
    
            var dOJParameter = dOJ.HasValue ?
                new ObjectParameter("DOJ", dOJ) :
                new ObjectParameter("DOJ", typeof(System.DateTime));
    
            var fatherNameParameter = fatherName != null ?
                new ObjectParameter("FatherName", fatherName) :
                new ObjectParameter("FatherName", typeof(string));
    
            var fatherOccupationParameter = fatherOccupation.HasValue ?
                new ObjectParameter("FatherOccupation", fatherOccupation) :
                new ObjectParameter("FatherOccupation", typeof(int));
    
            var fatherMobileNumberParameter = fatherMobileNumber != null ?
                new ObjectParameter("FatherMobileNumber", fatherMobileNumber) :
                new ObjectParameter("FatherMobileNumber", typeof(string));
    
            var motherNameParameter = motherName != null ?
                new ObjectParameter("MotherName", motherName) :
                new ObjectParameter("MotherName", typeof(string));
    
            var motherOccupationParameter = motherOccupation.HasValue ?
                new ObjectParameter("MotherOccupation", motherOccupation) :
                new ObjectParameter("MotherOccupation", typeof(int));
    
            var motherMobileNumberParameter = motherMobileNumber != null ?
                new ObjectParameter("MotherMobileNumber", motherMobileNumber) :
                new ObjectParameter("MotherMobileNumber", typeof(string));
    
            var address1Parameter = address1 != null ?
                new ObjectParameter("Address1", address1) :
                new ObjectParameter("Address1", typeof(string));
    
            var address2Parameter = address2 != null ?
                new ObjectParameter("Address2", address2) :
                new ObjectParameter("Address2", typeof(string));
    
            var cityIdParameter = cityId.HasValue ?
                new ObjectParameter("CityId", cityId) :
                new ObjectParameter("CityId", typeof(int));
    
            var studentPhotoParameter = studentPhoto != null ?
                new ObjectParameter("StudentPhoto", studentPhoto) :
                new ObjectParameter("StudentPhoto", typeof(string));
    
            var fatherPhotoParameter = fatherPhoto != null ?
                new ObjectParameter("FatherPhoto", fatherPhoto) :
                new ObjectParameter("FatherPhoto", typeof(string));
    
            var motherPhotoParameter = motherPhoto != null ?
                new ObjectParameter("MotherPhoto", motherPhoto) :
                new ObjectParameter("MotherPhoto", typeof(string));
    
            var emailIdParameter = emailId != null ?
                new ObjectParameter("EmailId", emailId) :
                new ObjectParameter("EmailId", typeof(string));
    
            var timingsParameter = timings != null ?
                new ObjectParameter("Timings", timings) :
                new ObjectParameter("Timings", typeof(string));
    
            var feesParameter = fees.HasValue ?
                new ObjectParameter("fees", fees) :
                new ObjectParameter("fees", typeof(double));
    
            var studentSourceParameter = studentSource.HasValue ?
                new ObjectParameter("StudentSource", studentSource) :
                new ObjectParameter("StudentSource", typeof(int));
    
            var admissionRemarksParameter = admissionRemarks != null ?
                new ObjectParameter("AdmissionRemarks", admissionRemarks) :
                new ObjectParameter("AdmissionRemarks", typeof(string));
    
            var createdByParameter = createdBy.HasValue ?
                new ObjectParameter("CreatedBy", createdBy) :
                new ObjectParameter("CreatedBy", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("usp_StudentInsert", studentNameParameter, genderParameter, dOBParameter, dOJParameter, fatherNameParameter, fatherOccupationParameter, fatherMobileNumberParameter, motherNameParameter, motherOccupationParameter, motherMobileNumberParameter, address1Parameter, address2Parameter, cityIdParameter, studentPhotoParameter, fatherPhotoParameter, motherPhotoParameter, emailIdParameter, timingsParameter, feesParameter, studentSourceParameter, admissionRemarksParameter, createdByParameter);
        }
    
        public virtual ObjectResult<usp_StudentbyIDGet_Result> usp_StudentbyIDGet(Nullable<int> studentID)
        {
            var studentIDParameter = studentID.HasValue ?
                new ObjectParameter("StudentID", studentID) :
                new ObjectParameter("StudentID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<usp_StudentbyIDGet_Result>("usp_StudentbyIDGet", studentIDParameter);
        }
    }
}
