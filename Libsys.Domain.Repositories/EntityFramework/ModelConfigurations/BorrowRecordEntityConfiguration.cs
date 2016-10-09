using Libsys.Domain.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Libsys.Domain.Repositories.EntityFramework.ModelConfigurations
{
    public class BorrowRecordEntityConfiguration : EntityTypeConfiguration<BorrowRecord>
    {
        public BorrowRecordEntityConfiguration()
        {
            ToTable("BorrowRecord");

            HasKey(x => x.ID);
            Property(x => x.ID)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.BorrowDate)
                .HasColumnType("date")
               .IsRequired();
            Property(x => x.DueDate)
                .HasColumnType("date")
               .IsRequired();
            Property(x => x.ReturnDate)
                .HasColumnType("date")
                .IsOptional();

            //一对多关系
            HasRequired<Reader>(x => x.Reader)
                .WithMany(x => x.BorrowRecords)
                .HasForeignKey(x => x.ReaderID);
            HasRequired<Book>(x => x.Book)
                .WithMany(x => x.BorrowRecords)
                .HasForeignKey(x => x.BookID);
        }
    }
}
