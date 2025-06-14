using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using REEP.Identity.Models.DomainModels;

namespace REEP.Identity.Data.Configurations
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasKey(user => user.Id);

            builder.HasIndex(user => user.Email)
                .IsUnique();
            builder.HasIndex(user => user.CreatedAt);
            builder.HasIndex(user => user.UpdatedAt);
            builder.HasIndex(user => user.DeletedAt);
            builder.HasIndex(user => user.IsDeleted);

            builder.Property(user => user.FirstName)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(user => user.LastName)
                .HasMaxLength(50);
            builder.Property(user => user.Email)
                .IsRequired()
                .HasMaxLength(50)
                .HasAnnotation("RegularExpression", @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            builder.Property(user => user.OtherContacts)
                .HasMaxLength(100);
            builder.Property(user => user.PasswordHash)
                .IsRequired()
                .HasMaxLength(64)
                .HasColumnType("bytea");
            builder.Property(user => user.CreatedAt)
                .IsRequired()
                .HasColumnType("timestamp with time zone")
                .HasDefaultValueSql("NOW()");
            builder.Property(user => user.UpdatedAt)
                .HasColumnType("timestamp with time zone");
            builder.Property(user => user.DeletedAt)
                .HasColumnType("timestamp with time zone");
            builder.Property(user => user.IsDeleted)
                .IsRequired()
                .HasColumnType("boolean")
                .HasDefaultValue(false);
        }
    }
}
