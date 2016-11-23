using System.Web;
using System.Web.Mvc;

namespace Lab6_RyanWall_WebDesign
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
