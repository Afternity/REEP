using REEP.Domain.Models.MaintenanceModels.MaintenanceTypeModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace REEP.Persistence.Data.EntityTypeConfigurations.MaintenanceConfigurations.MaintenanceTypeConfigurations
{
    public class MaintenanceTypeConfiguration : IEntityTypeConfiguration<MaintenanceType>
    {
        public void Configure(EntityTypeBuilder<MaintenanceType> builder)
        {
            builder.HasKey(maintenanceType => maintenanceType.Id);

            builder.HasIndex(maintenanceType => maintenanceType.Type)
                .IsUnique();
            builder.HasIndex(maintenanceType => maintenanceType.CreatedAt);
            builder.HasIndex(maintenanceType => maintenanceType.UpdatedAt);
            builder.HasIndex(maintenanceType => maintenanceType.DeletedAt);
            builder.HasIndex(maintenanceType => maintenanceType.IsDeleted);

            builder.Property(maintenanceType => maintenanceType.Type)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(maintenanceType => maintenanceType.CreatedAt)
                .IsRequired()
                .HasColumnType("timestamp with time zone")
                .HasDefaultValueSql("NOW()");
            builder.Property(maintenanceType => maintenanceType.UpdatedAt)
                .HasColumnType("timestamp with time zone");
            builder.Property(maintenanceType => maintenanceType.DeletedAt)
                .HasColumnType("timestamp with time zone");
            builder.Property(maintenanceType => maintenanceType.IsDeleted)
                .IsRequired()
                .HasColumnType("boolean")
                .HasDefaultValue(false);

            builder.HasMany(maintenanceType => maintenanceType.Maintenances)
                .WithOne(maintenance => maintenance.MaintenanceType)
                .HasForeignKey(maintenance => maintenance.MaintenanceTypeId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
