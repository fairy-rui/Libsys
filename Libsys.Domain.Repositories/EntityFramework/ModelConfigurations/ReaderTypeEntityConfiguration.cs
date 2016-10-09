using Libsys.Domain.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Libsys.Domain.Repositories.EntityFramework.ModelConfigurations
{
    public class ReaderTypeEntityConfiguration : EntityTypeConfiguration<ReaderType>
    {
        public ReaderTypeEntityConfiguration()
        {
            ToTable("ReaderType");

            HasKey(x => x.ID);
            Property(x => x.ID)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TypeName)
                .IsRequired()
                .HasMaxLength(64)
                .IsUnicode();
            Property(x => x.BookMaxBorrowed)
                .IsRequired();
            Property(x => x.BookMaxReserved)
                .IsRequired();
            Property(x => x.LoanPeriod)
                .IsRequired();
            Property(x => x.Renewed)
                .IsRequired();
            Property(x => x.Reserved)
                .IsRequired();
        }
    }
}
