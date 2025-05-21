using REEP.Domain.Models.UserModels.UserTypeModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace REEP.Persistence.Data.EntityTypeConfigurations.UserConfigurations.UserTypeConfigurations
{
    public class UserTypeConfiguration : IEntityTypeConfiguration<UserType>
    {
        public void Configure(EntityTypeBuilder<UserType> builder)
        {
            builder.HasKey(user => user.Id);

            builder.Property(user => user.Type)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(user => user.CreateDate)
                .IsRequired()
                .HasColumnType("timestamp with time zone");
            builder.Property(user => user.UpdateDate)
                .HasColumnType("timestamp with time zone");

            builder.HasMany(userType => userType.Users)
                .WithOne(user => user.UserType)
                .HasForeignKey(user => user.UserTypeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
