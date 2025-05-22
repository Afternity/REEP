using REEP.Domain.Models.PassportModels.PassportTypeModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace REEP.Persistence.Data.EntityTypeConfigurations.PassportConfigurations.PassportTypeConfigurations
{
    public class StatusTypeConfiguration : IEntityTypeConfiguration<StatusType>
    {
        public void Configure(EntityTypeBuilder<StatusType> builder)
        {
            builder.HasKey(statusType => statusType.Id);

            builder.HasIndex(statusType => statusType.CreateDate);
            builder.HasIndex(statusType => statusType.UpdateDate);

            builder.Property(statusType => statusType.Type)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(statusType => statusType.CreateDate)
                .IsRequired()
                .HasColumnType("timestamp with time zone");
            builder.Property(statusType => statusType.UpdateDate)
                .HasColumnType("timestamp with time zone");

            builder.HasMany(statusType => statusType.Statuses)
                .WithOne(status => status.StatusType)
                .HasForeignKey(status => status.StatusTypeId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
