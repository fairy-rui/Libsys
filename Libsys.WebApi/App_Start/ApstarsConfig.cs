using Apstars.Bootstrapper;
using Apstars.Config.Fluent;
using Apstars.ObjectContainers.Autofac;
using Autofac;
using Autofac.Integration.WebApi;
using System.Linq;
using System.Reflection;
using System.Web.Compilation;
using System.Web.Http;

namespace Libsys.WebApi
{
    public static class ApstarsConfig
    {
        public static void Initialize()
        {
            AppRuntime
                .Instance
                .ConfigureApstars()
                .UsingAutofacContainerWithDefaultSettings()
                .Create((sender, e) =>
                {
                    //用GetReferencedAssemblies方法获取当前应用程序下所有的程序集  
                    var assemblies = BuildManager.GetReferencedAssemblies().Cast<Assembly>().ToArray();
                    e.ObjectContainer.RegisterAssemblyModules(assemblies).Build();

                    var container = e.ObjectContainer.GetWrappedContainer<IContainer>();
                    GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
                })
                .Start();
        }
    }
}