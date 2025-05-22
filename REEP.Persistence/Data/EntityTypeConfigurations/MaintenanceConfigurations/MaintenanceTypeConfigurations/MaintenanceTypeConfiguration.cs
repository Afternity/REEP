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
            builder.HasIndex(maintenanceType => maintenanceType.CreateDate);
            builder.HasIndex(maintenanceType => maintenanceType.UpdateDate);

            builder.Property(maintenanceType => maintenanceType.Type)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(maintenanceType => maintenanceType.CreateDate)
                .IsRequired()
                .HasColumnType("timestamp with time zone");
            builder.Property(maintenanceType => maintenanceType.UpdateDate)
                .HasColumnType("timestamp with time zone");

            builder.HasMany(maintenanceType => maintenanceType.Maintenances)
                .WithOne(maintenance => maintenance.MaintenanceType)
                .HasForeignKey(maintenance => maintenance.MaintenanceTypeId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
