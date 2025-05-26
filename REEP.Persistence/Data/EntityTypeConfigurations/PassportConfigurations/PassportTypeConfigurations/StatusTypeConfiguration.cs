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

            builder.HasIndex(statusType => statusType.Type)
                .IsUnique();
            builder.HasIndex(statusType => statusType.CreatedAt);
            builder.HasIndex(statusType => statusType.UpdatedAt);
            builder.HasIndex(statusType => statusType.DeletedAt);
            builder.HasIndex(statusType => statusType.IsDeleted);

            builder.Property(statusType => statusType.Type)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(statusType => statusType.CreatedAt)
                .IsRequired()
                .HasColumnType("timestamp with time zone")
                .HasDefaultValueSql("NOW()");
            builder.Property(statusType => statusType.UpdatedAt)
                .HasColumnType("timestamp with time zone");
            builder.Property(statusType => statusType.DeletedAt)
                .HasColumnType("timestamp with time zone");
            builder.Property(statusType => statusType.IsDeleted)
                .IsRequired()
                .HasColumnType("boolean")
                .HasDefaultValue(false);

            builder.HasMany(statusType => statusType.Statuses)
                .WithOne(status => status.StatusType)
                .HasForeignKey(status => status.StatusTypeId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
