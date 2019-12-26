using AnnualMeeting2020.Web.App_Start;
using System.Web;
using System.Web.Mvc;

namespace AnnualMeeting2020.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //filters.Add(new HandleErrorAttribute());
            filters.Add(new CustomExceptionFilterAttribute());
        }
    }
}
