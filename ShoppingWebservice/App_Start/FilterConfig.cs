using System.Runtime.Remoting;
using System.Web;
using System.Web.Mvc;
using ShoppingWebservice.ErrorHandling;

namespace ShoppingWebservice {
    public class FilterConfig {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters) {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
