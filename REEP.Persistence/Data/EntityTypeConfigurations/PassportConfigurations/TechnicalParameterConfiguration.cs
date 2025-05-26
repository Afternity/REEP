using REEP.Domain.Models.PassportModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace REEP.Persistence.Data.EntityTypeConfigurations.PassportConfigurations
{
    public class TechnicalParameterConfiguration : IEntityTypeConfiguration<TechnicalParameter>
    {
        public void Configure(EntityTypeBuilder<TechnicalParameter> builder)
        {
            builder.HasKey(technicalParameter => technicalParameter.Id);

            builder.HasIndex(t => t.Parameters)
                .HasMethod("GIN");
            builder.HasIndex(technicalParameter => technicalParameter.CreatedAt);
            builder.HasIndex(technicalParameter => technicalParameter.UpdatedAt);
            builder.HasIndex(technicalParameter => technicalParameter.DeletedAt);
            builder.HasIndex(technicalParameter => technicalParameter.IsDeleted);

            builder.Property(technicalParameter => technicalParameter.Parameters)
                .IsRequired()
                .HasColumnType("jsonb")
                .HasConversion(
                    v => v ?? "{}",
                    v => v
                    );
            builder.Property(technicalParameter => technicalParameter.CreatedAt)
                .IsRequired()
                .HasColumnType("timestamp with time zone")
                .HasDefaultValueSql("NOW()");
            builder.Property(technicalParameter => technicalParameter.UpdatedAt)
                .HasColumnType("timestamp with time zone");
            builder.Property(technicalParameter => technicalParameter.DeletedAt)
                .HasColumnType("timestamp with time zone");
            builder.Property(technicalParameter => technicalParameter.IsDeleted)
                .IsRequired()
                .HasColumnType("boolean")
                .HasDefaultValue(false);

            builder.HasMany(technicalParameter => technicalParameter.Equipments)
                .WithOne(equipment => equipment.TechnicalParameter)
                .HasForeignKey(equipment => equipment.TechnicalParameterId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
