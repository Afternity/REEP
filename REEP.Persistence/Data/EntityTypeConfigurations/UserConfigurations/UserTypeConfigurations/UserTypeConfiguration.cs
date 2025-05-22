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
            builder.HasIndex(userType => userType.CreateDate);
            builder.HasIndex(userType => userType.UpdateDate);

            builder.Property(userType => userType.Type)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(userType => userType.CreateDate)
                .IsRequired()
                .HasColumnType("timestamp with time zone");
            builder.Property(userType => userType.UpdateDate)
                .HasColumnType("timestamp with time zone");

            builder.HasMany(userType => userType.Users)
                .WithOne(user => user.UserType)
                .HasForeignKey(user => user.UserTypeId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
