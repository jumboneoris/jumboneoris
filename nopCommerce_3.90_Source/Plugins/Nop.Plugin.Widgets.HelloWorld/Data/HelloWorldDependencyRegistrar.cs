using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Core;
using Nop.Core.Configuration;
using Nop.Core.Data;
using Nop.Core.Infrastructure;
using Nop.Core.Infrastructure.DependencyManagement;
using Nop.Data;
using Nop.Web.Framework.Mvc;

namespace Nop.Plugin.Widgets.HelloWorld.Data
{
    public class HelloWorldDependencyRegistrar : IDependencyRegistrar
    {
        private const string CONTEXT_NAME = "nop_object_context_hello_world";
        public int Order { get { return 1; } }

        public void Register(global::Autofac.ContainerBuilder builder, ITypeFinder typeFinder, NopConfig config)
        {
            this.RegisterPluginDataContext<HelloWorldObjectContext>(builder, CONTEXT_NAME);
            builder.RegisterType<EfRepository<HelloWorld.Domain.HelloWorldRecord>>()
            .As<IRepository<HelloWorld.Domain.HelloWorldRecord>>()
            .WithParameter(ResolvedParameter.ForNamed<IDbContext>(CONTEXT_NAME))
            .InstancePerLifetimeScope();
        }
    }
}
