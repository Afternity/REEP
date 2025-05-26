using REEP.Domain.Models.WarrantyModels.WarrantyTypeModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace REEP.Persistence.Data.EntityTypeConfigurations.WarrantyConfigurations.WarrantyTypeConfigurations
{
    public class WarrantyTypeConfiguration : IEntityTypeConfiguration<WarrantyType>
    {
        public void Configure(EntityTypeBuilder<WarrantyType> builder)
        {
            builder.HasKey(warrantyType => warrantyType.Id);

            builder.HasIndex(warrantyType => warrantyType.Type)
                .IsUnique();
            builder.HasIndex(warrantyType => warrantyType.CreatedAt);
            builder.HasIndex(warrantyType => warrantyType.UpdatedAt);
            builder.HasIndex(warrantyType => warrantyType.DeletedAt);
            builder.HasIndex(warrantyType => warrantyType.IsDeleted);

            builder.Property(warrantyType => warrantyType.Type)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(warrantyType => warrantyType.CreatedAt)
                .IsRequired()
                .HasColumnType("timestamp with time zone")
                .HasDefaultValueSql("NOW()");
            builder.Property(warrantyType => warrantyType.UpdatedAt)
                .HasColumnType("timestamp with time zone");
            builder.Property(warrantyType => warrantyType.DeletedAt)
               .HasColumnType("timestamp with time zone");
            builder.Property(warrantyType => warrantyType.IsDeleted)
                .IsRequired()
                .HasColumnType("boolean")
                .HasDefaultValue(false);

            builder.HasMany(warrantyType => warrantyType.Warranties)
                .WithOne(warranty => warranty.WarrantyType)
                .HasForeignKey(warranty => warranty.WarrantyTypeId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
