using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Routing;
using Nop.Core.Plugins;
using Nop.Plugin.Widgets.HelloWorld.Data;
using Nop.Services.Cms;
using Nop.Services.Localization;

namespace Nop.Plugin.Widgets.HelloWorld
{
    public class HelloWorldService : BasePlugin, IWidgetPlugin
    {
        private HelloWorldObjectContext _context;

        public HelloWorldService(HelloWorldObjectContext context)
        {
            _context = context;
        }

        public void GetConfigurationRoute(out string actionName, out string controllerName, out RouteValueDictionary routeValues)
        {
            actionName = "Configure";
            controllerName = "HelloWorld";
            routeValues = new RouteValueDictionary() { { "NameSpaces", "Nop.Plugin.Widgets.HelloWorld.Controllers" },
                {"area",null } };
        }

        public void GetDisplayWidgetRoute(string widgetZone, out string actionName, out string controllerName, out RouteValueDictionary routeValues)
        {
            actionName = "HelloWorldWidget";
            controllerName = "HelloWorld";
            routeValues = new RouteValueDictionary() { { "NameSpaces", "Nop.Plugin.Widgets.HelloWorld.Controllers" },
                {"area",null },{"widgetZones",widgetZone } };
        }

        public IList<string> GetWidgetZones()
        {
            return new List<string>();
        }

        public override void Install()
        {
            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.HelloWorld.Message", "Ingrese el mensaje que desea mostrar");
            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.HelloWorld.UrlImg", "Ingrese la url donde estara ubicada la imagen");
            _context.Install();
            base.Install();
        }


        public override void Uninstall()
        {
            this.DeletePluginLocaleResource("Plugins.Widgets.HelloWorld.Message");
            this.DeletePluginLocaleResource("Plugins.Widgets.HelloWorld.UrlImg");
            _context.Unistall();
            base.Uninstall();
        }
    }
}
