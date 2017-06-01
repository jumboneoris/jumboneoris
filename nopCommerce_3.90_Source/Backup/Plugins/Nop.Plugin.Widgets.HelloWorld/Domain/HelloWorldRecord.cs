using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Core;
using Nop.Web.Framework;

namespace Nop.Plugin.Widgets.HelloWorld.Domain
{
    public partial class HelloWorldRecord : BaseEntity
    {
        [NopResourceDisplayName("Plugins.Widgets.HelloWorld.Message")]
        public string Message { get; set; }
        [NopResourceDisplayName("Plugins.Widgets.HelloWorld.UrlImg")]
        public string UrlImg { get; set; }
    }
}
