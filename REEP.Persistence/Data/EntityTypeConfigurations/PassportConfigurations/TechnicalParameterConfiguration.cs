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
            builder.HasIndex(technicalParameter => technicalParameter.CreateDate);
            builder.HasIndex(technicalParameter => technicalParameter.UpdateDate);

            builder.Property(technicalParameter => technicalParameter.Parameters)
                .IsRequired()
                .HasColumnType("jsonb")
                .HasConversion(
                    v => v ?? "{}",
                    v => v
                    );
            builder.Property(technicalParameter => technicalParameter.CreateDate)
                .IsRequired()
                .HasColumnType("timestamp with time zone");
            builder.Property(technicalParameter => technicalParameter.UpdateDate)
                .HasColumnType("timestamp with time zone");

            builder.HasMany(technicalParameter => technicalParameter.Equipments)
                .WithOne(equipment => equipment.TechnicalParameter)
                .HasForeignKey(equipment => equipment.TechnicalParameterId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
