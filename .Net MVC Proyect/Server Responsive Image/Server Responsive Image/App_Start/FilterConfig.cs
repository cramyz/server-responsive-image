using System.Web;
using System.Web.Mvc;

namespace Server_Responsive_Image
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
