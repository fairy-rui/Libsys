using Apstars.Repositories;
using Apstars.Repositories.EntityFramework;
using Autofac;
using Autofac.Integration.WebApi;
using Libsys.Domain.Repositories.EntityFramework;
using System.Data.Entity;
using System.Web.Http;

namespace Libsys.WebApi
{
    public class LibsysModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(new LibsysContext())
                .As<DbContext>()
                .InstancePerLifetimeScope();

            builder.RegisterType<EntityFrameworkRepositoryContext>()
                .As<IRepositoryContext>()
                .InstancePerLifetimeScope();    //InstancePerLifetimeScope 保证对象生命周期基于请求

            builder.RegisterGeneric(typeof(EntityFrameworkRepository<>))
                .As(typeof(IRepository<>))
                .InstancePerDependency();   //每次请求都会返回新的实例   

            var config = GlobalConfiguration.Configuration;
            // Register your Web API controllers.
            builder.RegisterApiControllers(System.Reflection.Assembly.GetExecutingAssembly());
            // OPTIONAL: Register the Autofac filter provider.
            builder.RegisterWebApiFilterProvider(config);
        }
    }
}