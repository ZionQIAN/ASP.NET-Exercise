using System.Web;
using System.Web.Mvc;

namespace FIT5032WK4_CodeFirst_2rd
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
