using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using REEP.Domain.Models.PassportModels;
using REEP.Domain.Models.UserModels;

namespace REEP.Persistence.Data.EntityTypeConfigurations.UserConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(user => user.Id);

            builder.HasIndex(user => user.Email)
                .IsUnique();
            builder.HasIndex(user => user.PasswordHash);
            builder.HasIndex(user => user.PasswordSalt);

            builder.Property(user => user.FirstName)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(user => user.SecondName)
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
                .HasColumnType("bytea");
            builder.Property(user => user.PasswordSalt)
                .IsRequired()
                .HasColumnType("bytea");
            builder.Property(user => user.CreateDate)
                .IsRequired()
                .HasColumnType("timestamp with time zone");
            builder.Property(user => user.UpdateDate)
                .HasColumnType("timestamp with time zone");

            builder.HasOne(user => user.UserType)
                .WithMany(userType => userType.Users)
                .HasForeignKey(user => user.UserTypeId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(user => user.UserUsedEquipmentPassports)
                .WithOne(equipmentPassport => equipmentPassport.UserUsed)
                .HasForeignKey(equipmentPassport => equipmentPassport.UserUsedId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(user => user.UserGrantAccessEquipmentPassports)
                .WithOne(equipmentPassport => equipmentPassport.UserGrantAccess)
                .HasForeignKey(equipmentPassport => equipmentPassport.UserGrantAccessId)
                .OnDelete(DeleteBehavior.SetNull);
            builder.HasMany(user => user.CreatedRequests)
                .WithOne(maintenanceRequest => maintenanceRequest.CreateByUser)
                .HasForeignKey(maintenanceRequest => maintenanceRequest.CreateByUserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(user => user.ApprovedRequests)
                .WithOne(maintenanceRequest => maintenanceRequest.ApprovedByUser)
                .HasForeignKey(maintenanceRequest => maintenanceRequest.ApprovedByUserId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
