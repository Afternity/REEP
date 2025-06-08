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
            builder.HasIndex(payment => payment.CreatedAt);
            builder.HasIndex(payment => payment.UpdatedAt);
            builder.HasIndex(payment => payment.DeletedAt);
            builder.HasIndex(payment => payment.IsDeleted);

            builder.Property(payment => payment.Price)
                .IsRequired()
                .HasColumnType("numeric(18, 2)")
                .HasDefaultValue(decimal.Zero);
            builder.Property(payment => payment.OtherPrice)
                .HasMaxLength(50);
            builder.Property(payment => payment.FirstPay)
                .IsRequired()
                .HasColumnType("date");
            builder.Property(payment => payment.PeriodPay)
                .IsRequired()
                .HasColumnType("interval");
            builder.Property(payment => payment.LastPay)
                .IsRequired()
                .HasColumnType("date");
            builder.Property(payment => payment.CreatedAt)
                .IsRequired()
                .HasColumnType("timestamp with time zone")
                .HasDefaultValueSql("NOW()");
            builder.Property(payment => payment.UpdatedAt)
                .HasColumnType("timestamp with time zone");
            builder.Property(payment => payment.DeletedAt)
                .HasColumnType("timestamp with time zone");
            builder.Property(payment => payment.IsDeleted)
                .IsRequired()
                .HasColumnType("boolean")
                .HasDefaultValue(false);

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
