using ANC.Sales.Web.Mvc.Configuration.Contracts;

namespace ANC.Sales.Web.Mvc.Controllers
{
    public class SomeRouteDependencyController
    {
        private readonly IExternalRouteConfiguration _routeConfig;

        public SomeRouteDependencyController(IExternalRouteConfiguration routeConfig)
        {
            _routeConfig = routeConfig;

            var url = _routeConfig.AFirstAPI;
        }                
    }
}