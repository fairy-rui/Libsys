using Libsys.Domain.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Libsys.Domain.Repositories.EntityFramework.ModelConfigurations
{
    public class UserEntityConfiguration : EntityTypeConfiguration<User>
    {
        public UserEntityConfiguration()
        {
            ToTable("Users");

            HasKey(x => x.ID);
            Property(x => x.ID)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.CredentialNo)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(16);
            Property(x => x.IDNumber)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(32);
            Property(x => x.DateRegistered)           
                .IsRequired();
            Property(x => x.DateLastAuthenticated).IsOptional();
            Property(x => x.PasswordHash)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(256);
            Property(x => x.Name)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(32);
            Property(x => x.Email)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(128);
            Property(x => x.Sex)
                .IsOptional()
                .IsUnicode()
                .HasMaxLength(16);
            Property(x => x.Phone)
                .IsOptional()
                .IsUnicode()
                .HasMaxLength(16);

            //多对多关系            
            HasMany<Role>(u => u.Roles)
                .WithMany(r => r.Users)
                .Map(ur =>
                {            
                    ur.MapLeftKey("UserID");
                    ur.MapRightKey("RoleID");
                    ur.ToTable("UserRole");
                });

            //TPH
            Map<Reader>(m =>
            {
                m.Requires("UserType").HasValue((int)UserType.Reader);
            })
            .Map<Staff>(m => m.Requires("UserType").HasValue((int)UserType.Staff));

        }
    }
}
