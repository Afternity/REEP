using REEP.Domain.Models.PassportModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace REEP.Persistence.Data.EntityTypeConfigurations.PassportConfigurations
{
    public class StatusConfiguration : IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> builder)
        {
            builder.HasKey(status => status.Id);

            builder.HasIndex(status => status.IsActive);
            builder.HasIndex(status => status.StartedAt);
            builder.HasIndex(status => status.EndedAt);
            builder.HasIndex(status => status.CreatedAt);
            builder.HasIndex(status => status.UpdatedAt);
            builder.HasIndex(status => status.DeletedAt);
            builder.HasIndex(status => status.IsDeleted);

            builder.Property(status => status.IsActive)
                .IsRequired()
                .HasColumnType("boolean")
                .HasDefaultValue(false);
            builder.Property(status => status.StartedAt)
                .HasColumnType("timestamp with time zone");
            builder.Property(status => status.EndedAt)
                .HasColumnType("timestamp with time zone");
            builder.Property(status => status.CreatedAt)
                .IsRequired()
                .HasColumnType("timestamp with time zone")
                .HasDefaultValueSql("NOW()");
            builder.Property(status => status.UpdatedAt)
                .HasColumnType("timestamp with time zone");
            builder.Property(status => status.DeletedAt)
                .HasColumnType("timestamp with time zone");
            builder.Property(status => status.IsDeleted)
                .IsRequired()
                .HasColumnType("boolean")
                .HasDefaultValue(false);

            builder.HasOne(status => status.StatusType)
                .WithMany(statusType => statusType.Statuses)
                .HasForeignKey(status => status.StatusTypeId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(status => status.EquipmentPassports)
                .WithOne(equipmentPassport => equipmentPassport.Status)
                .HasForeignKey(equipmentPassport => equipmentPassport.StatusId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
