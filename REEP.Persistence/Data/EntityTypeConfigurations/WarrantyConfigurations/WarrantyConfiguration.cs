using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using REEP.Domain.Models.WarrantyModels;

namespace REEP.Persistence.Data.EntityTypeConfigurations.WarrantyConfigurations
{
    public class WarrantyConfiguration : IEntityTypeConfiguration<Warranty>
    {
        public void Configure(EntityTypeBuilder<Warranty> builder)
        {
            builder.HasKey(warranty => warranty.Id);

            builder.Property(warranty => warranty.Name)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(warranty => warranty.Description)
                .IsRequired()
                .HasMaxLength(150);
            builder.Property(warranty => warranty.DateStart)
                .IsRequired()
                .HasColumnType("date");
            builder.Property(warranty => warranty.DateEnd)
                .IsRequired()
                .HasColumnType("date");
            builder.Property(warranty => warranty.CreateDate)
                .IsRequired()
                .HasColumnType("timestamp with time zone");
            builder.Property(warranty => warranty.UpdateDate)
                .HasColumnType("timestamp with time zone");

            builder.HasOne(warranty => warranty.Contract)
                .WithMany(contract => contract.Warranties)
                .HasForeignKey(warranty => warranty.ContractId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(warranty => warranty.WarrantyType)
                .WithMany(warrantyType => warrantyType.Warranties)
                .HasForeignKey(warranty => warranty.WarrantyTypeId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(warranty => warranty.EquipmentPassports)
                .WithOne(equipmentPassport => equipmentPassport.Warranty)
                .HasForeignKey(equipmentPassport => equipmentPassport.WarrantyId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
