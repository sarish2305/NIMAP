using System.Web;
using System.Web.Mvc;

namespace Nimap_CRUD_Operation
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
