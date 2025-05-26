using REEP.Domain.Models.PassportModels.PassportTypeModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace REEP.Persistence.Data.EntityTypeConfigurations.PassportConfigurations.PassportTypeConfigurations
{
    public class EquipmentTypeConfiguration : IEntityTypeConfiguration<EquipmentType>
    {
        public void Configure(EntityTypeBuilder<EquipmentType> builder)
        {
            builder.HasKey(equipmentType => equipmentType.Id);

            builder.HasIndex(equipmentType => equipmentType.Type)
                .IsUnique();
            builder.HasIndex(equipmentType => equipmentType.CreatedAt);
            builder.HasIndex(equipmentType => equipmentType.UpdatedAt);
            builder.HasIndex(equipmentType => equipmentType.DeletedAt);
            builder.HasIndex(equipmentType => equipmentType.IsDeleted);

            builder.Property(equipmentType => equipmentType.Type)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(equipmentType => equipmentType.CreatedAt)
                .IsRequired()
                .HasColumnType("timestamp with time zone")
                .HasDefaultValueSql("NOW()");
            builder.Property(equipmentType => equipmentType.UpdatedAt)
                .HasColumnType("timestamp with time zone");
            builder.Property(equipmentType => equipmentType.DeletedAt)
                .HasColumnType("timestamp with time zone");
            builder.Property(equipmentType => equipmentType.IsDeleted)
                .IsRequired()
                .HasColumnType("boolean")
                .HasDefaultValue(false);

            builder.HasMany(equipmentType => equipmentType.Equipments)
                .WithOne(equipment => equipment.EquipmentType)
                .HasForeignKey(equipment => equipment.EquipmentTypeId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
