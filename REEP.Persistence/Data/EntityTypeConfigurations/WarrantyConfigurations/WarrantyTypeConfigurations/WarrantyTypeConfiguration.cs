﻿using REEP.Domain.Models.WarrantyModels.WarrantyTypeModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace REEP.Persistence.Data.EntityTypeConfigurations.WarrantyConfigurations.WarrantyTypeConfigurations
{
    public class WarrantyTypeConfiguration : IEntityTypeConfiguration<WarrantyType>
    {
        public void Configure(EntityTypeBuilder<WarrantyType> builder)
        {
            builder.HasKey(warrantyType => warrantyType.Id);

            builder.Property(warrantyType => warrantyType.Type)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(warrantyType => warrantyType.CreateDate)
                .IsRequired()
                .HasColumnType("timestamp with time zone");
            builder.Property(warrantyType => warrantyType.UpdateDate)
                .HasColumnType("timestamp with time zone");

            builder.HasMany(warrantyType => warrantyType.Warranties)
                .WithOne(warranty => warranty.WarrantyType)
                .HasForeignKey(warranty => warranty.WarrantyTypeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
