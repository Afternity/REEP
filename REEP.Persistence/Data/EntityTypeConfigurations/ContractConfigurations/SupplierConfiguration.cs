using REEP.Domain.Models.ContractModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace REEP.Persistence.Data.EntityTypeConfigurations.ContractConfigurations
{
    public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.HasKey(supplier => supplier.Id);


            builder.HasIndex(supplier => supplier.Email)
                .IsUnique();
            builder.HasIndex(supplier => supplier.CreatedAt);
            builder.HasIndex(supplier => supplier.UpdatedAt);
            builder.HasIndex(supplier => supplier.DeletedAt);
            builder.HasIndex(supplier => supplier.IsDeleted);

            builder.Property(supplier => supplier.FirstName)
                .HasMaxLength(50);
            builder.Property(supplier => supplier.SecondName)
                .HasMaxLength(50);
            builder.Property(supplier => supplier.LastName)
                .HasMaxLength(50);
            builder.Property(supplier => supplier.OtherName)
                .HasMaxLength(100);
            //не дописал Number
            builder.Property(supplier => supplier.Email)
                .HasMaxLength(50)
                .HasAnnotation("RegularExpression", @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            builder.Property(supplier => supplier.OtherContacts)
                .HasMaxLength(100);
            builder.Property(supplier => supplier.CreatedAt)
             .IsRequired()
             .HasColumnType("timestamp with time zone")
             .HasDefaultValueSql("NOW()");
            builder.Property(supplier => supplier.UpdatedAt)
                .HasColumnType("timestamp with time zone");
            builder.Property(supplier => supplier.DeletedAt)
                .HasColumnType("timestamp with time zone");
            builder.Property(supplier => supplier.IsDeleted)
                .IsRequired()
                .HasColumnType("boolean")
                .HasDefaultValue(false);

            builder.HasOne(supplier => supplier.SupplierType)
                .WithMany(supplierType => supplierType.Suppliers)
                .HasForeignKey(supplier => supplier.SupplierTypeId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(supplier => supplier.ContractsAndSuppliers)
                .WithOne(contractAndSupplier => contractAndSupplier.Supplier)
                .HasForeignKey(contractAndSupplier => contractAndSupplier.SupplierId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
