using REEP.Domain.Models.PassportModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using REEP.Domain.Models.WarrantyModels;

namespace REEP.Persistence.Data.EntityTypeConfigurations.PassportConfigurations
{
    public class EquipmentPassportConfiguration : IEntityTypeConfiguration<EquipmentPassport>
    {
        public void Configure(EntityTypeBuilder<EquipmentPassport> builder)
        {
            builder.HasKey(equipmentPassport => equipmentPassport.Id);

            builder.HasIndex(equipmentPassport => equipmentPassport.Number)
                .IsUnique();
            builder.HasIndex(equipmentPassport => equipmentPassport.CreatedAt);
            builder.HasIndex(equipmentPassport => equipmentPassport.UpdatedAt);
            builder.HasIndex(equipmentPassport => equipmentPassport.DeletedAt);
            builder.HasIndex(equipmentPassport => equipmentPassport.IsDeleted);
            builder.HasIndex(equipmentPassport => equipmentPassport.UserUsedId);
            builder.HasIndex(equipmentPassport => equipmentPassport.EquipmentId);
            builder.HasIndex(equipmentPassport => equipmentPassport.StatusId);

            builder.Property(equipmentPassport => equipmentPassport.Number)
                .IsRequired()
                .HasMaxLength(200);
            builder.Property(equipmentPassport => equipmentPassport.CreatedAt)
                .IsRequired()
                .HasColumnType("timestamp with time zone")
                .HasDefaultValueSql("NOW()");
            builder.Property(equipmentPassport => equipmentPassport.UpdatedAt)
                .HasColumnType("timestamp with time zone");
            builder.Property(equipmentPassport => equipmentPassport.DeletedAt)
                .HasColumnType("timestamp with time zone");
            builder.Property(equipmentPassport => equipmentPassport.IsDeleted)
                .IsRequired()
                .HasColumnType("boolean")
                .HasDefaultValue(false);

            builder.HasOne(equipmentPassport => equipmentPassport.UserUsed)
                .WithMany(user => user.UserUsedEquipmentPassports)
                .HasForeignKey(equipmentPassport => equipmentPassport.UserUsedId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(equipmentPassport => equipmentPassport.UserGrantAccess)
                .WithMany(user => user.UserGrantAccessEquipmentPassports)
                .HasForeignKey(equipmentPassport => equipmentPassport.UserGrantAccessId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(equipmentPassport => equipmentPassport.Equipment)
                .WithMany(equipment => equipment.EquipmentPassports)
                .HasForeignKey(equipmentPassport => equipmentPassport.EquipmentId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(equipmentPassport => equipmentPassport.Status)
                .WithMany(status => status.EquipmentPassports)
                .HasForeignKey(equipmentPassport => equipmentPassport.StatusId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(equipmentPassport => equipmentPassport.Location)
                .WithMany(location => location.EquipmentPassports)
                .HasForeignKey(equipmentPassport => equipmentPassport.LocationId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
