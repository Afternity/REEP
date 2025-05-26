using REEP.Domain.Models.PassportModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace REEP.Persistence.Data.EntityTypeConfigurations.PassportConfigurations
{
    public class LocationConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.HasKey(location => location.Id);

            builder.HasIndex(location => location.Name);
            builder.HasIndex(location => location.Address);
            builder.HasIndex(location => location.CreatedAt);
            builder.HasIndex(location => location.UpdatedAt);
            builder.HasIndex(location => location.DeletedAt);
            builder.HasIndex(location => location.IsDeleted);

            builder.Property(location => location.Name)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(location => location.Description)
                .HasMaxLength(100);
            builder.Property(location => location.Address)
                .HasMaxLength (100);
            builder.Property(location => location.CreatedAt)
                .IsRequired()
                .HasColumnType("timestamp with time zone")
                .HasDefaultValueSql("NOW()");
            builder.Property(location => location.UpdatedAt)
                .HasColumnType("timestamp with time zone");
            builder.Property(location => location.DeletedAt)
                .HasColumnType("timestamp with time zone");
            builder.Property(location => location.IsDeleted)
                .IsRequired()
                .HasColumnType("boolean")
                .HasDefaultValue(false);

            builder.HasMany(location => location.EquipmentPassports)
                .WithOne(equipmentPassport => equipmentPassport.Location)
                .HasForeignKey(equipmentPassport => equipmentPassport.LocationId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
