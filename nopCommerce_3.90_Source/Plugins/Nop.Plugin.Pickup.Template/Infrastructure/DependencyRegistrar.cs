using Autofac;
using Autofac.Core;
using Nop.Core.Configuration;
using Nop.Core.Data;
using Nop.Core.Infrastructure;
using Nop.Core.Infrastructure.DependencyManagement;
using Nop.Data;
using Nop.Plugin.Pickup.Plantilla.Data;
using Nop.Plugin.Pickup.Plantilla.Domain;
using Nop.Plugin.Pickup.Plantilla.Services;
using Nop.Web.Framework.Mvc;

namespace Nop.Plugin.Pickup.Plantilla.Infrastructure
{
    /// <summary>
    /// Dependency registrar
    /// </summary>
    public class DependencyRegistrar : IDependencyRegistrar
    {
        /// <summary>
        /// Register services and interfaces
        /// </summary>
        /// <param name="builder">Container builder</param>
        /// <param name="typeFinder">Type finder</param>
        /// <param name="config">Config</param>
        public virtual void Register(ContainerBuilder builder, ITypeFinder typeFinder, NopConfig config)
        {
            builder.RegisterType<StorePlantillaService>().As<IStorePlantillaService>().InstancePerLifetimeScope();

            //data context
            this.RegisterPluginDataContext<StorePlantillaObjectContext>(builder, "nop_object_context_plantilla-pickup");

            //override required repository with our custom context
            builder.RegisterType<EfRepository<StorePlantillaRecord>>()
                .As<IRepository<StorePlantillaRecord>>()
                .WithParameter(ResolvedParameter.ForNamed<IDbContext>("nop_object_context_plantilla-pickup"))
                .InstancePerLifetimeScope();
        }

        /// <summary>
        /// Order of this dependency registrar implementation
        /// </summary>
        public int Order
        {
            get { return 1; }
        }
    }
}
