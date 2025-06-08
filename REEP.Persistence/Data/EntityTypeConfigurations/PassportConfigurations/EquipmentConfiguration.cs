using REEP.Domain.Models.PassportModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace REEP.Persistence.Data.EntityTypeConfigurations.PassportConfigurations
{
    public class EquipmentConfiguration : IEntityTypeConfiguration<Equipment>
    {
        public void Configure(EntityTypeBuilder<Equipment> builder)
        {
            builder.HasKey(equipment => equipment.Id);

            builder.HasIndex(equipment => equipment.Name);
            builder.HasIndex(equipment => equipment.CreatedAt);
            builder.HasIndex(equipment => equipment.UpdatedAt);
            builder.HasIndex(equipment => equipment.DeletedAt);
            builder.HasIndex(equipment => equipment.IsDeleted);
            builder.HasIndex(equipment => equipment.EquipmentTypeId);
            builder.HasIndex(equipment => equipment.TechnicalParameterId);

            builder.Property(equipment => equipment.Name)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(equipment => equipment.CreatedAt)
                .IsRequired()
                .HasColumnType("timestamp with time zone")
                .HasDefaultValueSql("NOW()");
            builder.Property(equipment => equipment.UpdatedAt)
                .HasColumnType("timestamp with time zone");
            builder.Property(equipment => equipment.DeletedAt)
                .HasColumnType("timestamp with time zone");
            builder.Property(equipment => equipment.IsDeleted)
                .IsRequired()
                .HasColumnType("boolean")
                .HasDefaultValue(false);

            builder.HasOne(equipment => equipment.EquipmentType)
                .WithMany(equipmentType => equipmentType.Equipments)
                .HasForeignKey(equipment => equipment.EquipmentTypeId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(equipment => equipment.TechnicalParameter)
                .WithMany(technicalParameter => technicalParameter.Equipments)
                .HasForeignKey(equipment => equipment.TechnicalParameterId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(equipment => equipment.Warranty)
                .WithMany(warranty => warranty.Equipments)
                .HasForeignKey(equipment => equipment.WarrantyId)
                .OnDelete(DeleteBehavior.SetNull);
            builder.HasMany(equipment => equipment.EquipmentPassports)
                .WithOne(equipmentPassport => equipmentPassport.Equipment)
                .HasForeignKey(equipmentPassport => equipmentPassport.EquipmentId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
