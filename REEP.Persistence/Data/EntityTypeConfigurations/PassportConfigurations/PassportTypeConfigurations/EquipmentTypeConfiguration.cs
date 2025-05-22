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

            builder.HasIndex(equipmentType => equipmentType.CreateDate);
            builder.HasIndex(equipmentType => equipmentType.UpdateDate);

            builder.Property(equipmentType => equipmentType.Type)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(equipmentType => equipmentType.CreateDate)
                .IsRequired()
                .HasColumnType("timestamp with time zone");
            builder.Property(equipmentType => equipmentType.UpdateDate)
                .HasColumnType("timestamp with time zone");

            builder.HasMany(equipmentType => equipmentType.Equipments)
                .WithOne(equipment => equipment.EquipmentType)
                .HasForeignKey(equipment => equipment.EquipmentTypeId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
