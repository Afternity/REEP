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

            builder.HasIndex(status => status.CreateDate);
            builder.HasIndex(status => status.UpdateDate);
            builder.HasIndex(status => status.StatusTypeId);

            builder.Property(status => status.IsActive)
                .IsRequired()
                .HasDefaultValue(false)
                .HasColumnType("boolean");
            builder.Property(status => status.StartActive)
                .HasColumnType("timestamp with time zone");
            builder.Property(status => status.EndActive)
                .HasColumnType("timestamp with time zone");
            builder.Property(status => status.CreateDate)
                .IsRequired()
                .HasColumnType("timestamp with time zone");
            builder.Property(status => status.UpdateDate)
                .HasColumnType("timestamp with time zone");

            builder.HasOne(status => status.StatusType)
                .WithMany(statusType => statusType.Statuses)
                .HasForeignKey(status => status.StatusTypeId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(status => status.EquipmentPassports)
                .WithOne(equipmentPassport => equipmentPassport.Status)
                .HasForeignKey(equipmentPassport => equipmentPassport.StatusId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
