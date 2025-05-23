using REEP.Domain.Models.ContractModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace REEP.Persistence.Data.EntityTypeConfigurations.ContractConfigurations
{
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.HasKey(payment => payment.Id);

            builder.HasIndex(payment => payment.FirstPay);
            builder.HasIndex(payment => payment.LastPay);
            builder.HasIndex(payment => payment.CreateDate);
            builder.HasIndex(payment => payment.UpdateDate);

            // пропустил поле Price не помню как работать с decimal
            builder.Property(payment => payment.FirstPay)
                .IsRequired()
                .HasColumnType("date");
            builder.Property(payment => payment.PeriodPay)
                .IsRequired()
                .HasColumnType("interval");
            builder.Property(payment => payment.LastPay)
                .IsRequired()
                .HasColumnType("date");
            builder.Property(payment => payment.CreateDate)
                .IsRequired()
                .HasColumnType("timestamp with time zone");
            builder.Property(payment => payment.UpdateDate)
                .HasColumnType("timestamp with time zone");

            builder.HasOne(payment => payment.PaymentType)
                .WithMany(paymentType => paymentType.Payments)
                .HasForeignKey(payment => payment.PaymentTypeId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(payment => payment.ContractsAndPayments)
                .WithOne(contractAndPayment => contractAndPayment.Payment)
                .HasForeignKey(contractAndPayment => contractAndPayment.PaymentId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
