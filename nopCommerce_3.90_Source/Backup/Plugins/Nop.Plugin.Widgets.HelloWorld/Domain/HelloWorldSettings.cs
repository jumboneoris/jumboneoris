using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Core;
using Nop.Core.Configuration;

namespace Nop.Plugin.Widgets.HelloWorld.Domain
{
    public partial class HelloWorldSettings : ISettings
    {
        public string Message { get; set; }
        public string UrlImg { get; set; }
    }
}
