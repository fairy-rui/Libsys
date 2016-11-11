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
    public class AuthorEntityConfiguration : EntityTypeConfiguration<Author>
    {
        public AuthorEntityConfiguration()
        {
            ToTable("Authors");

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
            Property(x => x.Email)                
                .IsOptional()
                .HasMaxLength(64)
                .IsUnicode();
        }
    }
}
