using System.Web.Mvc;

namespace HumptyDumptyPlaySchool.Areas.Comman
{
    public class CommanAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Comman";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Comman_default",
                "Comman/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}