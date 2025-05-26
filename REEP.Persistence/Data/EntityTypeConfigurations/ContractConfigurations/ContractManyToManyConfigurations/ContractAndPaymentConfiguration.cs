using REEP.Domain.Models.ContractModels.ContractManyToManyModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace REEP.Persistence.Data.EntityTypeConfigurations.ContractConfigurations.ContractManyToManyConfigurations
{
    public class ContractAndPaymentConfiguration : IEntityTypeConfiguration<ContractAndPayment>
    {
        public void Configure(EntityTypeBuilder<ContractAndPayment> builder)
        {
            builder.HasKey(contractAndPayment => new
            {
                contractAndPayment.ContractId,
                contractAndPayment.PaymentId
            });

            builder.HasIndex(contractAndPayment => contractAndPayment.IsActive);
            builder.HasIndex(contractAndPayment => contractAndPayment.CreatedAt);
            builder.HasIndex(contractAndPayment => contractAndPayment.UpdatedAt);
            builder.HasIndex(contractAndPayment => contractAndPayment.DeletedAt);
            builder.HasIndex(contractAndPayment => contractAndPayment.IsDeleted);

            builder.Property(contractAndPayment => contractAndPayment.IsActive)
                .IsRequired()
                .HasColumnType("boolean")
                .HasDefaultValue(true);
            builder.Property(contractAndPayment => contractAndPayment.CreatedAt)
                .IsRequired()
                .HasColumnType("timestamp with time zone")
                .HasDefaultValueSql("NOW()");
            builder.Property(contractAndPayment => contractAndPayment.UpdatedAt)
                .HasColumnType("timestamp with time zone");
            builder.Property(contractAndPayment => contractAndPayment.DeletedAt)
                .HasColumnType("timestamp with time zone");
            builder.Property(contractAndPayment => contractAndPayment.IsDeleted)
                .IsRequired()
                .HasColumnType("boolean")
                .HasDefaultValue(false);
        }
    }
}
