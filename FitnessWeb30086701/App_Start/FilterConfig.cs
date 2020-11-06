using System.Web;
using System.Web.Mvc;

namespace FitnessWeb30086701
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
