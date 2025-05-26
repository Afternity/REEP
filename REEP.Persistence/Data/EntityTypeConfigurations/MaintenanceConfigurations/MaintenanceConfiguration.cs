using REEP.Domain.Models.MaintenanceModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace REEP.Persistence.Data.EntityTypeConfigurations.MaintenanceConfigurations
{
    public class MaintenanceConfiguration : IEntityTypeConfiguration<Maintenance>
    {
        public void Configure(EntityTypeBuilder<Maintenance> builder)
        {
            builder.HasKey(maintenance =>  maintenance.Id);

            builder.HasIndex(maintenance => maintenance.IsActive);
            builder.HasIndex(maintenance => maintenance.StartedAt);
            builder.HasIndex(maintenance => maintenance.EndedAt);
            builder.HasIndex(maintenance => maintenance.CreatedAt);
            builder.HasIndex(maintenance => maintenance.UpdatedAt);
            builder.HasIndex(maintenance => maintenance.DeletedAt);
            builder.HasIndex(maintenance => maintenance.IsDeleted);

            builder.Property(maintenance => maintenance.IsActive)
                .IsRequired()
                .HasColumnType("boolean")
                .HasDefaultValue(false);
            builder.Property(maintenance => maintenance.TotalDescription)
                .IsRequired()
                .HasMaxLength(1000);
            builder.Property(maintenance => maintenance.StartedAt)
                .IsRequired()
                .HasColumnType("date");
            builder.Property(maintenance => maintenance.PossibleRepairTime)
                .IsRequired()
                .HasColumnType("interval");
            builder.Property(maintenance => maintenance.EndedAt)
                .IsRequired()
                .HasColumnType("date");
            builder.Property(maintenance => maintenance.CreatedAt)
              .IsRequired()
              .HasColumnType("timestamp with time zone")
              .HasDefaultValueSql("NOW()");
            builder.Property(maintenance => maintenance.UpdatedAt)
                .HasColumnType("timestamp with time zone");
            builder.Property(maintenance => maintenance.DeletedAt)
                .HasColumnType("timestamp with time zone");
            builder.Property(maintenance => maintenance.IsDeleted)
                .IsRequired()
                .HasColumnType("boolean")
                .HasDefaultValue(false);

            builder.HasOne(maintenance => maintenance.MaintenanceType)
                .WithMany(maintenanceType => maintenanceType.Maintenances)
                .HasForeignKey(maintenance => maintenance.MaintenanceTypeId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(maintenance => maintenance.MaintenanceRequests)
                .WithOne(maintenanceRequest => maintenanceRequest.Maintenance)
                .HasForeignKey(maintenanceRequest => maintenanceRequest.MaintenanceId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
