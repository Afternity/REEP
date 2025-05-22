using REEP.Domain.Models.PassportModels;
using REEP.Domain.Models.UserModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace REEP.Persistence.Data.EntityTypeConfigurations.PassportConfigurations
{
    public class EquipmentPassportConfiguration : IEntityTypeConfiguration<EquipmentPassport>
    {
        public void Configure(EntityTypeBuilder<EquipmentPassport> builder)
        {
            builder.HasKey(equipmentPassport => equipmentPassport.Id);

            builder.HasIndex(equipmentPassport => equipmentPassport.Number)
                .IsUnique();
            builder.HasIndex(equipmentPassport => equipmentPassport.CreateDate);
            builder.HasIndex(equipmentPassport => equipmentPassport.UpdateDate);
            builder.HasIndex(equipmentPassport => equipmentPassport.UserUsedId);
            builder.HasIndex(equipmentPassport => equipmentPassport.EquipmentId);
            builder.HasIndex(equipmentPassport => equipmentPassport.StatusId);

            builder.Property(equipmentPassport => equipmentPassport.Number)
                .IsRequired()
                .HasMaxLength(200);
            builder.Property(equipmentPassport => equipmentPassport.CreateDate)
                .IsRequired()
                .HasColumnType("timestamp with time zone");
            builder.Property(equipmentPassport => equipmentPassport.UpdateDate)
                .HasColumnType("timestamp with time zone");

            builder.HasOne(equipmentPassport => equipmentPassport.UserUsed)
                .WithMany(user => user.UserUsedEquipmentPassports)
                .HasForeignKey(equipmentPassport => equipmentPassport.UserUsedId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(equipmentPassport => equipmentPassport.UserGrantAccess)
                .WithMany(user => user.UserGrantAccessEquipmentPassports)
                .HasForeignKey(equipmentPassport => equipmentPassport.UserGrantAccessId)
                .OnDelete(DeleteBehavior.Restrict);
            // надо доделать, я побежал делать TypeConfigurations
        }
    }
}
