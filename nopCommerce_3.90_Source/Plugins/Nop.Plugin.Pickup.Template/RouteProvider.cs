using System.Web.Mvc;
using System.Web.Routing;
using Nop.Web.Framework.Mvc.Routes;

namespace Nop.Plugin.Pickup.Plantilla
{
    public partial class RouteProvider : IRouteProvider
    {
        public void RegisterRoutes(RouteCollection routes)
        {
            routes.MapRoute("Plugin.Pickup.Plantilla.Create",
                 "Plugins/Plantilla/Create",
                 new { controller = "Plantilla", action = "Create", },
                 new[] { "Nop.Plugin.Pickup.Plantilla.Controllers" }
            );

            routes.MapRoute("Plugin.Pickup.Plantilla.Edit",
                 "Plugins/Plantilla/Edit",
                 new { controller = "Plantilla", action = "Edit" },
                 new[] { "Nop.Plugin.Pickup.Plantilla.Controllers" }
            );
        }
        public int Priority
        {
            get
            {
                return 0;
            }
        }
    }
}
