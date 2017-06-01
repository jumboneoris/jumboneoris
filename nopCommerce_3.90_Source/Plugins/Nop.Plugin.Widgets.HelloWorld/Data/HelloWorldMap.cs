using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Data.Mapping;
using Nop.Plugin.Widgets.HelloWorld.Domain;

namespace Nop.Plugin.Widgets.HelloWorld.Data
{
    public class HelloWorldMap : NopEntityTypeConfiguration<HelloWorldRecord>
    {
        public HelloWorldMap()
        {
            ToTable("HelloWorld");
            HasKey(hw => hw.Id);
            Property(hw => hw.Message);
            Property(hw => hw.UrlImg);
        }
    }
}
