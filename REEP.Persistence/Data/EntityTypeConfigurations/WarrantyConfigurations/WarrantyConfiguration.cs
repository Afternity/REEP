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

            builder.HasIndex(warranty => warranty.StartedAt);
            builder.HasIndex(warranty => warranty.EndedAt);
            builder.HasIndex(warranty => warranty.CreatedAt);
            builder.HasIndex(warranty => warranty.UpdatedAt);
            builder.HasIndex(warranty => warranty.DeletedAt);
            builder.HasIndex(warranty => warranty.IsDeleted);

            builder.Property(warranty => warranty.Name)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(warranty => warranty.Description)
                .IsRequired()
                .HasMaxLength(150);
            builder.Property(warranty => warranty.StartedAt)
                .IsRequired()
                .HasColumnType("date");
            builder.Property(warranty => warranty.EndedAt)
                .IsRequired()
                .HasColumnType("date");
            builder.Property(warranty => warranty.CreatedAt)
                .IsRequired()
                .HasColumnType("timestamp with time zone")
                .HasDefaultValueSql("NOW()");
            builder.Property(warranty => warranty.UpdatedAt)
                .HasColumnType("timestamp with time zone");
            builder.Property(warranty => warranty.DeletedAt)
                .HasColumnType("timestamp with time zone");
            builder.Property(warranty => warranty.IsDeleted)
                .IsRequired()
                .HasColumnType("boolean")
                .HasDefaultValue(false);

            builder.HasOne(warranty => warranty.Contract)
                .WithMany(contract => contract.Warranties)
                .HasForeignKey(warranty => warranty.ContractId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(warranty => warranty.WarrantyType)
                .WithMany(warrantyType => warrantyType.Warranties)
                .HasForeignKey(warranty => warranty.WarrantyTypeId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(warranty => warranty.Equipments)
                .WithOne(equipment => equipment.Warranty)
                .HasForeignKey(equipment => equipment.WarrantyId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
