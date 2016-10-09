using Libsys.Domain.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Libsys.Domain.Repositories.EntityFramework.ModelConfigurations
{
    public class RoleEntityConfiguration : EntityTypeConfiguration<Role>
    {
        public RoleEntityConfiguration()
        {
            ToTable("Roles");

            HasKey(x => x.ID);
            Property(x => x.ID).IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Name).IsUnicode()
                .IsRequired()
                .HasMaxLength(16);
            Property(x => x.Description).IsUnicode()
                .IsOptional()
                .HasMaxLength(256);           
        }
    }
}
