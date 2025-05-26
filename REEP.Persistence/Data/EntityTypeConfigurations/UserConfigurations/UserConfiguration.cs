﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
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
            builder.HasIndex(user => user.CreatedAt);
            builder.HasIndex(user => user.UpdatedAt);
            builder.HasIndex(user => user.DeletedAt);
            builder.HasIndex(user => user.IsDeleted);

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
                .HasMaxLength(64)
                .HasColumnType("bytea");
            builder.Property(user => user.PasswordSalt)
                .IsRequired()
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
