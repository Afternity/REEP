using REEP.Domain.Models.ContractModels.ContractHistoryModels;
using REEP.Domain.Models.ContractModels.ContractManyToManyModels;
using REEP.Domain.Models.ContractModels.ContractTypeModels;
using REEP.Domain.Models.ContractModels;
using REEP.Domain.Models.MaintenanceModels.MaintenanceHistoryModels;
using REEP.Domain.Models.MaintenanceModels.MaintenanceTypeModels;
using REEP.Domain.Models.MaintenanceModels;
using REEP.Domain.Models.PassportModels.PassportHistory;
using REEP.Domain.Models.PassportModels.PassportTypeModels;
using REEP.Domain.Models.PassportModels;
using REEP.Domain.Models.UserModels.UserTypeModels;
using REEP.Domain.Models.UserModels;
using REEP.Domain.Models.WarrantyModels.WarrantyTypeModels;
using REEP.Domain.Models.WarrantyModels;
using Microsoft.EntityFrameworkCore;


namespace REEP.Persistence.Data.DbContexts
{
    public class ReepDbContext : DbContext
    {
        private readonly DbContextOptions<ReepDbContext> _options;

        public ReepDbContext(DbContextOptions<ReepDbContext> options) 
            :base(options) =>
            _options = options;

        public DbSet<ContractParametersHistory> ContractParametersHistories { get; set; }
        public DbSet<ContractAndPayment> ContractsAndPayments { get; set; }
        public DbSet<ContractAndSupplier> ContractsAndSuppliers { get; set; }
        public DbSet<ContractType> ContractTypes { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }
        public DbSet<SupplierType> SupplierTypes { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<MaintenаnceParametersHistory> MaintenаnceParametersHistories { get; set; }
        public DbSet<MaintenanceType> MaintenanceTypes { get; set; }
        public DbSet<Maintenance> Maintenances { get; set; }
        public DbSet<MaintenanceRequest> MaintenanceRequests { get; set; }
        public DbSet<EquipmentParametersHistory> EquipmentParametersHistories { get; set; }
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

            base.OnModelCreating(modelBuilder);
        }
    }
}
