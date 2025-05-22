using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using REEP.Domain.Models.ContractModels.ContractTypeModels;

namespace REEP.Persistence.Data.EntityTypeConfigurations.ContractConfigurations.ContractTypeConfigurations
{
    public class SupplierTypeConfiguration : IEntityTypeConfiguration<SupplierType>
    {
        public void Configure(EntityTypeBuilder<SupplierType> builder)
        {
            builder.HasKey(supplierType => supplierType.Id);

            builder.HasIndex(supplierType => supplierType.Type)
                .IsUnique();
            builder.HasIndex(supplierType => supplierType.CreateDate);
            builder.HasIndex(supplierType => supplierType.UpdateDate);

            builder.Property(supplierType => supplierType.Type)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(supplierType => supplierType.CreateDate)
                .IsRequired()
                .HasColumnType("timestamp with time zone");
            builder.Property(supplierType => supplierType.UpdateDate)
                .HasColumnType("timestamp with time zone");

            builder.HasMany(supplierType => supplierType.Suppliers)
                .WithOne(supplier => supplier.SupplierType)
                .HasForeignKey(supplier => supplier.SupplierTypeId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
