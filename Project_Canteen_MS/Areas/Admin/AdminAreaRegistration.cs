using System.Web.Mvc;

namespace Project_Canteen_MS.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }
        [Authorize]
        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new {Controller = "HomeAdmin",action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}