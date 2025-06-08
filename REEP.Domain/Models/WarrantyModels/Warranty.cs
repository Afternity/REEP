using REEP.Domain.Models.PassportModels;
using REEP.Domain.Models.ContractModels;
using REEP.Domain.Models.WarrantyModels.WarrantyTypeModels;
using REEP.Domain.InterfaceModels;

namespace REEP.Domain.Models.WarrantyModels
{
    public class Warranty : IAuditable, ISoftDeletable
    {
        public Guid Id { get; set; }
        public string Name {get; set; } = string.Empty;
        public string Description {get; set; } = string.Empty;
        public DateTime StartedAt { get; set; }
        public DateTime EndedAt { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool IsDeleted { get; set; } = false;

        public Guid ContractId { get; set; }
        public Contract Contract { get; set; } = null!;
        public Guid WarrantyTypeId { get; set; }
        public WarrantyType WarrantyType { get; set; } = null!;
        public ICollection<Equipment> Equipments{ get; set; } = [];
    }
}
