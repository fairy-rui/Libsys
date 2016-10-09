using Libsys.Domain.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Libsys.Domain.Repositories.EntityFramework.ModelConfigurations
{
    public class CategoryEntityConfiguration : EntityTypeConfiguration<Category>
    {
        public CategoryEntityConfiguration()
        {
            ToTable("Category");

            HasKey(c => c.ID);
            Property(c => c.ID)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(64)
                .IsUnicode();
            Property(x => x.Description)
                .HasMaxLength(256)
                .IsUnicode();
        }
    }
}
