using Libsys.Domain.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Libsys.Domain.Repositories.EntityFramework.ModelConfigurations
{
    public class PrivilegeEntityConfiguration : EntityTypeConfiguration<Privilege>
    {
        public PrivilegeEntityConfiguration()
        {
            ToTable("Privilege");

            HasKey(x => x.ID);
            Property(x => x.ID)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(32)
                .IsUnicode();
            Property(x => x.Description)
                .HasMaxLength(256)
                .IsUnicode();
        }
    }
}
