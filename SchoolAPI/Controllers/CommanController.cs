using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PlaySchoolEntities;

namespace SchoolAPI.Controllers
{
    public class CommanController : ApiController
    {
        PlaySchoolEntities1 playschool = new PlaySchoolEntities1();
        [HttpGet]
        public List<usp_CountryGet_Result> GetCountries()
        {
            try
            {
                List<usp_CountryGet_Result> CounryList = playschool.usp_CountryGet().ToList();
                return CounryList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

      //  [HttpGet]
        public List<usp_StateGet_Result> GetStateList(int CountyId)
        {
            try
            {
                List<usp_StateGet_Result> StateList = playschool.usp_StateGet(CountyId).ToList();
                return StateList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public List<usp_CitiesGet_Result> GetCities(int StateId)
        {
            try
            {
                List<usp_CitiesGet_Result> CityList = playschool.usp_CitiesGet(StateId).ToList();
                return CityList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
