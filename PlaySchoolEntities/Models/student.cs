using System;
using System.ComponentModel.DataAnnotations;
namespace PlaySchoolEntities
{

    [MetadataType(typeof(StudentMetaData))]
    public partial class usp_StudentbyIDGet_Result
    {
    }
    public class StudentMetaData
    {
         public int StudentID { get; set; }
        [Required(AllowEmptyStrings =false,ErrorMessage ="Please enter the Student Name")]
        [MaxLength(50,ErrorMessage ="Name cannot be greater than 50 characters")]
        [MinLength(5,ErrorMessage ="Name cannot be less than 5 characters")]
        [Display(Name = "Student Full Name")]
        public string StudentName { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string CityName { get; set; }
        [Required]
        public string ZipCode { get; set; }
        [Required]
        public string StateName { get; set; }
        [Required]
        public string CountryName { get; set; }
        public Nullable<System.DateTime> DOB { get; set; }
        public Nullable<System.DateTime> DOJ { get; set; }
        [Required]
        public string FatherName { get; set; }
        public string FatherOccupation { get; set; }
       
        public string MotherOccupation { get; set; }
        public string FatherMobileNumber { get; set; }
        [Required]
        public string MotherName { get; set; }
        public string MotherMobileNumber { get; set; }
        [Required]
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string StudentPhoto { get; set; }
        public string FatherPhoto { get; set; }
        public string MotherPhoto { get; set; }
        public string EmailId { get; set; }
        public string Timings { get; set; }
        public Nullable<double> fees { get; set; }
        public string StudentSource { get; set; }
        public string AdmissionRemarks { get; set; }
     //   public Nullable<byte> status { get; set; }
        public string UserName { get; set; }
        public int CityID { get; set; }
        public int StateID { get; set; }
        public int CountryID { get; set; }
        public int UserID { get; set; }
        public int GenderId { get; set; }
        //public Nullable<int> FatherOccupationId { get; set; }
        //public Nullable<int> MotherOccupationId { get; set; }
        //public Nullable<int> StudentSourceId { get; set; }
    }
}