using REEP.Domain.Models.ContractModels.ContractTypeModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace REEP.Persistence.Data.EntityTypeConfigurations.ContractConfigurations.ContractTypeConfigurations
{
    public class PaymentTypeConfiguration : IEntityTypeConfiguration<PaymentType>
    {
        public void Configure(EntityTypeBuilder<PaymentType> builder)
        {
            builder.HasKey(paymentType => paymentType.Id);

            builder.HasIndex(paymentType => paymentType.Type)
                .IsUnique();
            builder.HasIndex(paymentType => paymentType.CreateDate);
            builder.HasIndex(paymentType => paymentType.UpdateDate);

            builder.Property(paymentType => paymentType.Type)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(paymentType => paymentType.CreateDate)
                .IsRequired()
                .HasColumnType("timestamp with time zone");
            builder.Property(paymentType => paymentType.UpdateDate)
                .HasColumnType("timestamp with time zone");

            builder.HasMany(paymentType => paymentType.Payments)
                .WithOne(payment => payment.PaymentType)
                .HasForeignKey(payment => payment.PaymentTypeId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
