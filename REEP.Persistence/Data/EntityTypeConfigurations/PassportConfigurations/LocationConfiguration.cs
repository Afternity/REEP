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
            builder.HasIndex(location => location.CreateDate);
            builder.HasIndex(location => location.UpdateDate);

            builder.Property(location => location.Name)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(location => location.Description)
                .HasMaxLength(100);
            builder.Property(location => location.Address)
                .HasMaxLength (100);
            builder.Property(location => location.CreateDate)
                .IsRequired()
                .HasColumnType("timestamp with time zone");
            builder.Property(location => location.UpdateDate)
                .HasColumnType("timestamp with time zone");

            builder.HasMany(location => location.EquipmentPassports)
                .WithOne(equipmentPassport => equipmentPassport.Location)
                .HasForeignKey(equipmentPassport => equipmentPassport.LocationId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
