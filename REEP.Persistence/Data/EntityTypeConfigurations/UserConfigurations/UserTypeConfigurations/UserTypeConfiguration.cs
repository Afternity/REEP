using REEP.Domain.Models.UserModels.UserTypeModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace REEP.Persistence.Data.EntityTypeConfigurations.UserConfigurations.UserTypeConfigurations
{
    public class UserTypeConfiguration : IEntityTypeConfiguration<UserType>
    {
        public void Configure(EntityTypeBuilder<UserType> builder)
        {
            builder.HasKey(userType => userType.Id);

            builder.HasIndex(userType => userType.Type)
                .IsUnique();
            builder.HasIndex(userType => userType.CreatedAt);
            builder.HasIndex(userType => userType.UpdatedAt);
            builder.HasIndex(userType => userType.DeletedAt);
            builder.HasIndex(userType => userType.IsDeleted);

            builder.Property(userType => userType.Type)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(userType => userType.CreatedAt)
                .IsRequired()
                .HasColumnType("timestamp with time zone")
                .HasDefaultValueSql("NOW()");
            builder.Property(userType => userType.UpdatedAt)
                .HasColumnType("timestamp with time zone");
            builder.Property(userType => userType.DeletedAt)
                .HasColumnType("timestamp with time zone");
            builder.Property(userType => userType.IsDeleted)
                .IsRequired()
                .HasColumnType("boolean")
                .HasDefaultValue(false);

            builder.HasMany(userType => userType.Users)
                .WithOne(user => user.UserType)
                .HasForeignKey(user => user.UserTypeId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
