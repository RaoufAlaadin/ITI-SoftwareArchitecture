using System.Web;
using System.Web.Mvc;

namespace CustomerOrder
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {

            //filters.Add(new AuthorizeAttribute());
            filters.Add(new HandleErrorAttribute()
            {
                View = "myErrorPage"
            });
        }
    }
}
