using REEP.Domain.Models.ContractModels;
using REEP.Domain.Models.ContractModels.ContractManyToManyModels;
using REEP.Domain.Models.ContractModels.ContractTypeModels;
using REEP.Domain.Models.MaintenanceModels;
using REEP.Domain.Models.MaintenanceModels.MaintenanceTypeModels;
using REEP.Domain.Models.PassportModels;
using REEP.Domain.Models.PassportModels.PassportTypeModels;
using REEP.Domain.Models.UserModels;
using REEP.Domain.Models.UserModels.UserTypeModels;
using REEP.Domain.Models.WarrantyModels;
using REEP.Domain.Models.WarrantyModels.WarrantyTypeModels;
using Microsoft.EntityFrameworkCore;

namespace REEP.Application.Interfaces.InterfaceDbContexts
{
    public interface IReepDbContext
    {
        DbSet<ContractAndPayment> ContractsAndPayments { get; set; }
        DbSet<ContractAndSupplier> ContractsAndSuppliers { get; set; }
        DbSet<ContractType> ContractTypes { get; set; }
        DbSet<PaymentType> PaymentTypes { get; set; }
        DbSet<SupplierType> SupplierTypes { get; set; }
        DbSet<Contract> Contracts { get; set; }
        DbSet<Payment> Payments { get; set; }
        DbSet<Supplier> Suppliers { get; set; }
        DbSet<MaintenanceType> MaintenanceTypes { get; set; }
        DbSet<Maintenance> Maintenances { get; set; }
        DbSet<MaintenanceRequest> MaintenanceRequests { get; set; }
        DbSet<EquipmentType> EquipmentTypes { get; set; }
        DbSet<StatusType> StatusTypes { get; set; }
        DbSet<Equipment> Equipment { get; set; }
        DbSet<EquipmentPassport> EquipmentPassports { get; set; }
        DbSet<Location> Location { get; set; }
        DbSet<Status> Status { get; set; }
        DbSet<TechnicalParameter> TechnicalParameters { get; set; }
        DbSet<UserType> UserTypes { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<WarrantyType> WarrantyTypes { get; set; }
        DbSet<Warranty> Warranties { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
