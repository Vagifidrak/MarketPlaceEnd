using System.Web.Mvc;

namespace MarketPlace.Areas.AdmiMarketPlace
{
    public class AdmiMarketPlaceAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "AdmiMarketPlace";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "AdmiMarketPlace_default",
                "AdmiMarketPlace/{controller}/{action}/{id}",
                new { action = "AdminHome, Index", id = UrlParameter.Optional }
            );
        }
    }
}