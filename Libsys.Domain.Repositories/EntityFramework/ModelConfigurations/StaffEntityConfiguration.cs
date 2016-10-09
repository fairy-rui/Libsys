using Libsys.Domain.Model;
using System.Data.Entity.ModelConfiguration;

namespace Libsys.Domain.Repositories.EntityFramework.ModelConfigurations
{
    public class StaffEntityConfiguration : EntityTypeConfiguration<Staff>
    {
        public StaffEntityConfiguration()
        {
            Property(x => x.EntryDate)
                .HasColumnType("date")
                .IsOptional();
        }
    }
}
