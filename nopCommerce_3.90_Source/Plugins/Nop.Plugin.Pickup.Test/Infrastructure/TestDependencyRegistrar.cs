using Autofac;
using Autofac.Core;
using Nop.Core.Configuration;
using Nop.Core.Data;
using Nop.Core.Infrastructure;
using Nop.Core.Infrastructure.DependencyManagement;
using Nop.Data;
using Nop.Web.Framework.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nop.Plugin.Pickup.Test.Infrastructure
{
    public class TestDependencyRegistrar : IDependencyRegistrar
    {
        // nop_object_context_{"Nombre del plugin"}
        private const string CONTEXT_NAME = "nop_object_context_test";
        public int Order { get { return 1; } }

        /// <summary>
        /// reemplazar del builder los Domain por los correspondientes.
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="typeFinder"></param>
        /// <param name="config"></param>
        public void Register(global::Autofac.ContainerBuilder builder, ITypeFinder typeFinder, NopConfig config)
        {
            this.RegisterPluginDataContext<Data.TestObjectContext>(builder, CONTEXT_NAME);
            builder.RegisterType<EfRepository<Domain.TestRecord>>()
            .As<IRepository<Domain.TestRecord>>()
            .WithParameter(ResolvedParameter.ForNamed<IDbContext>(CONTEXT_NAME))
            .InstancePerLifetimeScope();
        }
    }

}
