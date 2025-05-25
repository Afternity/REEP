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
            builder.HasIndex(contractType => contractType.CreatedAt);
            builder.HasIndex(contractType => contractType.UpdatedAt);
            builder.HasIndex(contractType => contractType.DeletedAt);
            builder.HasIndex(contractType => contractType.IsDeleted);

            builder.Property(contractType => contractType.Type)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(contractType => contractType.CreatedAt)
                .IsRequired()
                .HasColumnType("timestamp with time zone")
                .HasDefaultValueSql("NOW()");
            builder.Property(contractType => contractType.UpdatedAt)
                .HasColumnType("timestamp with time zone");
            builder.Property(contractType => contractType.DeletedAt)
                .HasColumnType("timestamp with time zone");
            builder.Property(contractType => contractType.IsDeleted)
                .IsRequired()
                .HasColumnType("boolean")
                .HasDefaultValue(false);

            builder.HasMany(contractType => contractType.Contracts)
                .WithOne(contract => contract.ContractType)
                .HasForeignKey(contract => contract.ContractTypeId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
