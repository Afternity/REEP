using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using REEP.Domain.Models.ContractModels;

namespace REEP.Persistence.Data.EntityTypeConfigurations.ContractConfigurations
{
    public class ContractConfigurtaion : IEntityTypeConfiguration<Contract>
    {
        public void Configure(EntityTypeBuilder<Contract> builder)
        {
            builder.HasKey(contract => contract.Id);

            builder.HasIndex(contract => contract.DateStart);
            builder.HasIndex(contract => contract.DateEnd);
            builder.HasIndex(contract => contract.CreateDate);
            builder.HasIndex(contract => contract.UpdateDate);

            builder.Property(contract => contract.Name)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(contract => contract.Description)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(contract => contract.DateStart)
                .IsRequired()
                .HasColumnType("date");
            builder.Property(contract => contract.DateEnd)
                .IsRequired()
                .HasColumnType("date");
            builder.Property(contract => contract.CreateDate)
                .IsRequired()
                .HasColumnType("timestamp with time zone");
            builder.Property(contract => contract.UpdateDate)
                .HasColumnType("timestamp with time zone");

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
