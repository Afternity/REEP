using REEP.Domain.Models.ContractModels.ContractManyToManyModels;
using REEP.Domain.Models.ContractModels.ContractTypeModels;
using REEP.Domain.Models.ContractModels;
using REEP.Domain.Models.MaintenanceModels.MaintenanceTypeModels;
using REEP.Domain.Models.MaintenanceModels;
using REEP.Domain.Models.PassportModels.PassportTypeModels;
using REEP.Domain.Models.PassportModels;
using REEP.Domain.Models.UserModels.UserTypeModels;
using REEP.Domain.Models.UserModels;
using REEP.Domain.Models.WarrantyModels.WarrantyTypeModels;
using REEP.Domain.Models.WarrantyModels;
using REEP.Persistence.Data.EntityTypeConfigurations.ContractConfigurations.ContractManyToManyConfigurations;
using REEP.Persistence.Data.EntityTypeConfigurations.ContractConfigurations.ContractTypeConfigurations;
using REEP.Persistence.Data.EntityTypeConfigurations.ContractConfigurations;
using REEP.Persistence.Data.EntityTypeConfigurations.MaintenanceConfigurations.MaintenanceTypeConfigurations;
using REEP.Persistence.Data.EntityTypeConfigurations.MaintenanceConfigurations;
using REEP.Persistence.Data.EntityTypeConfigurations.PassportConfigurations.PassportTypeConfigurations;
using REEP.Persistence.Data.EntityTypeConfigurations.PassportConfigurations;
using REEP.Persistence.Data.EntityTypeConfigurations.UserConfigurations.UserTypeConfigurations;
using REEP.Persistence.Data.EntityTypeConfigurations.UserConfigurations;
using REEP.Persistence.Data.EntityTypeConfigurations.WarrantyConfigurations.WarrantyTypeConfigurations;
using REEP.Persistence.Data.EntityTypeConfigurations.WarrantyConfigurations;
using Microsoft.EntityFrameworkCore;


namespace REEP.Persistence.Data.DbContexts
{
    public class ReepDbContext : DbContext
    {
        private readonly DbContextOptions<ReepDbContext> _options;

        public ReepDbContext(DbContextOptions<ReepDbContext> options) 
            :base(options) =>
            _options = options;

        public DbSet<ContractAndPayment> ContractsAndPayments { get; set; }
        public DbSet<ContractAndSupplier> ContractsAndSuppliers { get; set; }
        public DbSet<ContractType> ContractTypes { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }
        public DbSet<SupplierType> SupplierTypes { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<MaintenanceType> MaintenanceTypes { get; set; }
        public DbSet<Maintenance> Maintenances { get; set; }
        public DbSet<MaintenanceRequest> MaintenanceRequests { get; set; }
        public DbSet<EquipmentType> EquipmentTypes { get; set; }
        public DbSet<StatusType> StatusTypes { get; set; }
        public DbSet<Equipment> Equipment {  get; set; }
        public DbSet<EquipmentPassport> EquipmentPassports { get; set; }
        public DbSet<Location> Location { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<TechnicalParameter> TechnicalParameters { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<WarrantyType> WarrantyTypes { get; set; }
        public DbSet<Warranty> Warranties { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ContractAndPaymentConfiguration());
            modelBuilder.ApplyConfiguration(new ContractAndSupplierConfiguration());
            modelBuilder.ApplyConfiguration(new ContractTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PaymentTypeConfiguration());
            modelBuilder.ApplyConfiguration(new SupplierTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ContractConfiguration());
            modelBuilder.ApplyConfiguration(new PaymentConfiguration());
            modelBuilder.ApplyConfiguration(new SupplierConfiguration());

            modelBuilder.ApplyConfiguration(new MaintenanceTypeConfiguration());
            modelBuilder.ApplyConfiguration(new MaintenanceConfiguration());
            modelBuilder.ApplyConfiguration(new MaintenanceRequestConfiguration());

            modelBuilder.ApplyConfiguration(new EquipmentTypeConfiguration());
            modelBuilder.ApplyConfiguration(new StatusTypeConfiguration());
            modelBuilder.ApplyConfiguration(new EquipmentConfiguration());
            modelBuilder.ApplyConfiguration(new EquipmentPassportConfiguration());
            modelBuilder.ApplyConfiguration(new LocationConfiguration());
            modelBuilder.ApplyConfiguration(new StatusConfiguration());
            modelBuilder.ApplyConfiguration(new TechnicalParameterConfiguration());

            modelBuilder.ApplyConfiguration(new UserTypeConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());

            modelBuilder.ApplyConfiguration(new WarrantyTypeConfiguration());
            modelBuilder.ApplyConfiguration(new WarrantyConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
