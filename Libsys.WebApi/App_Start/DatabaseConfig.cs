using Libsys.Domain.Repositories.EntityFramework;
using System.Data.Entity;

namespace Libsys.WebApi
{
    public static class DatabaseConfig
    {
        public static void Initialize()
        {
#if DEBUG
            Database.SetInitializer(new LibsysDatabaseInitializationStrategy());
            new LibsysContext().Database.Initialize(true);
#else
            Database.SetInitializer<LibsysContext>(null);
#endif
        }
    }
}