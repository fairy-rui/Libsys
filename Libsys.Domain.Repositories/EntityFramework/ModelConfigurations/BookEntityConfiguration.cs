using Libsys.Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libsys.Domain.Repositories.EntityFramework.ModelConfigurations
{
    public class BookEntityConfiguration : EntityTypeConfiguration<Book>
    {
        public BookEntityConfiguration()
        {
            ToTable("Books");

            HasKey(c => c.ID);
            Property(c => c.ID)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(256)
                .IsUnicode();
            Property(x => x.Description)                
                .IsUnicode();
            Property(x => x.PublishDate)
                .HasColumnType("date")
                .IsOptional();
            Property(c => c.ISBN)
                .IsRequired()
                .HasMaxLength(64)
                .IsUnicode();
            Property(c => c.UnitPrice)
                .HasPrecision(4, 2);

            //多对多关系            
            HasMany<Category>(x => x.Categorization)
                .WithMany(c => c.Books)
                .Map(bc =>
                {
                    bc.MapLeftKey("BookID");
                    bc.MapRightKey("CategoryID");
                    bc.ToTable("Categorization");
                });
        }
    }
}
