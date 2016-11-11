using AutoMapper;
using System;
using System.Linq;
using System.Reflection;
using System.Web.Compilation;

namespace Libsys.WebApi
{
    /// <summary>
    /// Represents the configuration to the AutoMapper framework.
    /// </summary>
    public static class AutoMapperConfig
    {
        /// <summary>
        /// Initializes this instance.
        /// </summary>
        public static void Initialize()
        {
            //用GetReferencedAssemblies方法获取当前应用程序下所有的程序集  
            var assemblies = BuildManager.GetReferencedAssemblies().Cast<Assembly>().ToArray();
            Mapper.Initialize(cfg => cfg.AddProfiles(assemblies));

            try
            {
                // 验证配置
                Mapper.AssertConfigurationIsValid();
            }
            catch (Exception)
            {
            }
        }
    }
}