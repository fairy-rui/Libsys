using Libsys.Domain.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Libsys.Domain.Repositories.EntityFramework.ModelConfigurations
{
    public class PermissionEntityConfiguration : EntityTypeConfiguration<Permission>
    {
        public PermissionEntityConfiguration()
        {
            ToTable("Permission");

            HasKey(x => x.ID);
            Property(x => x.ID)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            //一对多关系
            HasRequired<Role>(x => x.Role)
                .WithMany(x => x.Permissions)
                .HasForeignKey(x => x.RoleID);
            HasRequired<Privilege>(x => x.Privilege)
                .WithMany(x => x.Roles)
                .HasForeignKey(x => x.PrivilegeID);
        }
    }
}
