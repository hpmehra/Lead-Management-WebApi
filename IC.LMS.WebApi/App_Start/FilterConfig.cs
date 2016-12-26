using IC.LMS.WebApi.App_Start;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace IC.LMS.WebApi
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            GlobalConfiguration.Configuration.Filters.Add(new HandleAndLogErrorAttribute());
            filters.Add(new HandleErrorAttribute());
          
        }
    }
}
