using REEP.Domain.Models.ContractModels.ContractManyToManyModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace REEP.Persistence.Data.EntityTypeConfigurations.ContractConfigurations.ContractManyToManyConfigurations
{
    public class ContractAndSupplierConfiguration : IEntityTypeConfiguration<ContractAndSupplier>
    {
        public void Configure(EntityTypeBuilder<ContractAndSupplier> builder)
        {
            builder.HasKey(contractAndSupplier => new
            {
                contractAndSupplier.Contract,
                contractAndSupplier.Supplier
            });

            builder.HasIndex(contractAndSupplier => contractAndSupplier.IsActive);
            builder.HasIndex(contractAndSupplier => contractAndSupplier.CreatedAt);
            builder.HasIndex(contractAndSupplier => contractAndSupplier.UpdatedAt);
            builder.HasIndex(contractAndSupplier => contractAndSupplier.DeletedAt);
            builder.HasIndex(contractAndSupplier => contractAndSupplier.IsDeleted);

            builder.Property(contractAndSupplier => contractAndSupplier.IsActive)
                .IsRequired()
                .HasColumnType("boolean")
                .HasDefaultValue(true);
            builder.Property(contractAndSupplier => contractAndSupplier.CreatedAt)
                .IsRequired()
                .HasColumnType("timestamp with time zone")
                .HasDefaultValueSql("NOW()");
            builder.Property(contractAndSupplier => contractAndSupplier.UpdatedAt)
                .HasColumnType("timestamp with time zone");
            builder.Property(contractAndSupplier => contractAndSupplier.DeletedAt)
                .HasColumnType("timestamp with time zone");
            builder.Property(contractAndSupplier => contractAndSupplier.IsDeleted)
                .IsRequired()
                .HasColumnType("boolean")
                .HasDefaultValue(false);
        }
    }
}
