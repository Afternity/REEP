using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using REEP.Domain.Models.ContractModels;

namespace REEP.Persistence.Data.EntityTypeConfigurations.ContractConfigurations
{
    public class ContractConfiguration : IEntityTypeConfiguration<Contract>
    {
        public void Configure(EntityTypeBuilder<Contract> builder)
        {
            builder.HasKey(contract => contract.Id);

            builder.HasIndex(contract => contract.StartedAt);
            builder.HasIndex(contract => contract.EndedAt);
            builder.HasIndex(contract => contract.CreatedAt);
            builder.HasIndex(contract => contract.UpdatedAt);
            builder.HasIndex(contract => contract.DeletedAt);
            builder.HasIndex(contract => contract.IsDeleted);

            builder.Property(contract => contract.Name)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(contract => contract.Description)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(contract => contract.StartedAt)
                .IsRequired()
                .HasColumnType("date");
            builder.Property(contract => contract.EndedAt)
                .IsRequired()
                .HasColumnType("date");
            builder.Property(contract => contract.CreatedAt)
                .IsRequired()
                .HasColumnType("timestamp with time zone")
                .HasDefaultValueSql("NOW()");
            builder.Property(contract => contract.UpdatedAt)
                .HasColumnType("timestamp with time zone");
            builder.Property(contract => contract.DeletedAt)
                .HasColumnType("timestamp with time zone");
            builder.Property(contract => contract.IsDeleted)
                .IsRequired()
                .HasColumnType("boolean")
                .HasDefaultValue(false);

            builder.HasOne(contract => contract.ContractType)
                .WithMany(contractType => contractType.Contracts)
                .HasForeignKey(contract => contract.ContractTypeId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(contract => contract.ContractsAndSuppliers)
                .WithOne(contractAndSupplier => contractAndSupplier.Contract)
                .HasForeignKey(contractAndSupplier => contractAndSupplier.ContractId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(contract => contract.ContractsAndPayments)
                .WithOne(contractAndSupplier => contractAndSupplier.Contract)
                .HasForeignKey(contractAndSupplier => contractAndSupplier.ContractId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(contract => contract.Warranties)
                .WithOne(warranty => warranty.Contract)
                .HasForeignKey(warranty => warranty.ContractId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
