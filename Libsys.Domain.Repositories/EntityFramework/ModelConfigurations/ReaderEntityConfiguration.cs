using Libsys.Domain.Model;
using System.Data.Entity.ModelConfiguration;

namespace Libsys.Domain.Repositories.EntityFramework.ModelConfigurations
{
    public class ReaderEntityConfiguration : EntityTypeConfiguration<Reader>
    {
        public ReaderEntityConfiguration()
        {
            Property(x => x.EffectiveDate)
                .HasColumnType("date")
                .IsRequired();
            Property(x => x.ExpirationDate)
                .HasColumnType("date")
                .IsRequired();

            HasRequired<ReaderType>(x => x.ReaderType)
                .WithMany(x => x.Readers)
                .HasForeignKey(x => x.ReaderTypeID);
        }
    }
}
