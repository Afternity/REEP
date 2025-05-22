using REEP.Domain.Models.ContractModels.ContractTypeModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace REEP.Persistence.Data.EntityTypeConfigurations.ContractConfigurations.ContractTypeConfigurations
{
    public class ContractTypeConfiguration : IEntityTypeConfiguration<ContractType>
    {
        public void Configure(EntityTypeBuilder<ContractType> builder)
        {
            builder.HasKey(contractType => contractType.Id);

            builder.HasIndex(contractType => contractType.Type)
                .IsUnique();
            builder.HasIndex(contractType => contractType.CreateDate);
            builder.HasIndex(contractType => contractType.UpdateDate);

            builder.Property(contractType => contractType.Type)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(contractType => contractType.CreateDate)
                .IsRequired()
                .HasColumnType("timestamp with time zone");
            builder.Property(contractType => contractType.UpdateDate)
                .HasColumnType("timestamp with time zone");

            builder.HasMany(contractType => contractType.Contracts)
                .WithOne(contract => contract.ContractType)
                .HasForeignKey(contract => contract.ContractTypeId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
