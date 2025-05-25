using REEP.Domain.Models.MaintenanceModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace REEP.Persistence.Data.EntityTypeConfigurations.MaintenanceConfigurations
{
    public class MaintenanceRequestConfiguration : IEntityTypeConfiguration<MaintenanceRequest>
    {
        public void Configure(EntityTypeBuilder<MaintenanceRequest> builder)
        {
            builder.HasKey(maintenanceRequest => maintenanceRequest.Id);

            builder.HasIndex(maintenanceRequest => maintenanceRequest.IsActive);
            builder.HasIndex(maintenanceRequest => maintenanceRequest.ReceiptedAt);
            builder.HasIndex(maintenanceRequest => maintenanceRequest.RegistedAt);
            builder.HasIndex(maintenanceRequest => maintenanceRequest.CreatedAt);
            builder.HasIndex(maintenanceRequest => maintenanceRequest.UpdatedAt);
            builder.HasIndex(maintenanceRequest => maintenanceRequest.DeletedAt);
            builder.HasIndex(maintenanceRequest => maintenanceRequest.IsDeleted);
            builder.HasIndex(maintenanceRequest => maintenanceRequest.MaintenanceId);

            builder.Property(maintenanceRequest => maintenanceRequest.IsActive)
                .IsRequired()
                .HasColumnType("boolean")
                .HasDefaultValue(false);
            builder.Property(maintenanceRequest => maintenanceRequest.Description)
                .IsRequired()
                .HasMaxLength(200);
            builder.Property(maintenanceRequest => maintenanceRequest.ReceiptedAt)
                .IsRequired()
                .HasColumnType("timestamp with time zone");
            builder.Property(maintenanceRequest => maintenanceRequest.RegistedAt)
                .HasColumnType("timestamp with time zone");
            builder.Property(maintenanceRequest => maintenanceRequest.CreatedAt)
              .IsRequired()
              .HasColumnType("timestamp with time zone")
              .HasDefaultValueSql("NOW()");
            builder.Property(maintenanceRequest => maintenanceRequest.UpdatedAt)
                .HasColumnType("timestamp with time zone");
            builder.Property(maintenanceRequest => maintenanceRequest.DeletedAt)
                .HasColumnType("timestamp with time zone");
            builder.Property(maintenanceRequest => maintenanceRequest.IsDeleted)
                .IsRequired()
                .HasColumnType("boolean")
                .HasDefaultValue(false);

            builder.HasOne(maintenanceRequest => maintenanceRequest.Maintenance)
                .WithMany(maintenance => maintenance.MaintenanceRequests)
                .HasForeignKey(maintenanceRequest => maintenanceRequest.MaintenanceId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(maintenanceRequest => maintenanceRequest.CreateByUser)
                .WithMany(user => user.CreatedRequests)
                .HasForeignKey(maintenanceRequest => maintenanceRequest.CreateByUserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(maintenanceRequest => maintenanceRequest.ApprovedByUser)
                .WithMany(user => user.ApprovedRequests)
                .HasForeignKey(maintenanceRequest => maintenanceRequest.ApprovedByUserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
