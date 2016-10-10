using Libsys.Domain.Model;
using System.Data.Entity;
using System.Reflection;

namespace Libsys.Domain.Repositories.EntityFramework
{
    /// <summary>
    /// Represents the DbContext implementation for Libsys.
    /// </summary>
    public class LibsysContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LibsysContext" /> class.
        /// </summary>
        public LibsysContext()
            : base("LibsysDB")
        {
        }

        /// <summary>
        /// Gets or sets the users.
        /// </summary>
        /// <value>
        /// The users.
        /// </value>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// Gets or sets the readerTypes.
        /// </summary>
        /// <value>
        /// The readerTypes.
        /// </value>
        public DbSet<ReaderType> ReaderTypes { get; set; }

        /// <summary>
        /// Gets or sets the roles.
        /// </summary>
        /// <value>
        /// The roles.
        /// </value>
        public DbSet<Role> Roles { get; set; }

        /// <summary>
        /// Gets or sets the privileges.
        /// </summary>
        /// <value>
        /// The privileges.
        /// </value>
        public DbSet<Privilege> Privileges { get; set; }

        /// <summary>
        /// Gets or sets the permissions.
        /// </summary>
        /// <value>
        /// The permissions.
        /// </value>
        public DbSet<Permission> Permissions { get; set; }

        /// <summary>
        /// Gets or sets the categories.
        /// </summary>
        /// <value>
        /// The categories.
        /// </value>
        public DbSet<Category> Categories { get; set; }

        /// <summary>
        /// Gets or sets the books.
        /// </summary>
        /// <value>
        /// The books.
        /// </value>
        public DbSet<Book> Books { get; set; }

        /// <summary>
        ///     This method is called when the model for a derived context has been initialized, but
        ///     before the model has been locked down and used to initialize the context.  The default
        ///     implementation of this method does nothing, but it can be overridden in a derived class
        ///     such that the model can be further configured before it is locked down.
        /// </summary>
        /// <param name="modelBuilder">The builder that defines the model for the context being created.</param>
        /// <remarks>
        ///     Typically, this method is called only once when the first instance of a derived context
        ///     is created.  The model for that context is then cached and is for all further instances of
        ///     the context in the app domain.  This caching can be disabled by setting the ModelCaching
        ///     property on the given ModelBuidler, but note that this can seriously degrade performance.
        ///     More control over caching is provided through use of the DbModelBuilder and DbContextFactory
        ///     classes directly.
        /// </remarks>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}
