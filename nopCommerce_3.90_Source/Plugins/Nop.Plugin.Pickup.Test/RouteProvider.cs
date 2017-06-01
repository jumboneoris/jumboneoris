using Nop.Web.Framework.Mvc.Routes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Nop.Plugin.Pickup.Test
{
    public class RouteProvider : IRouteProvider
    {
        public int Priority
        {
            get
            {
                return 0;
            }
        }

        public void RegisterRoutes(RouteCollection routes)
        {
            routes.MapRoute("Plugin.Pickup.Test.Create",
                 "Plugins/Test/Create",
                 new { controller = "Test", action = "Create", },
                 new[] { "Nop.Plugin.Pickup.Test.Controllers" }
            );

            routes.MapRoute("Plugin.Pickup.Test.Edit",
                 "Plugins/Test/Edit",
                 new { controller = "Test", action = "Edit" },
                 new[] { "Nop.Plugin.Pickup.Test.Controllers" }
            );
        }
    }
}