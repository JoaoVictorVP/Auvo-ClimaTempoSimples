using System.Web;
using System.Web.Mvc;

namespace Auvo.ClimaTempoSimples
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
