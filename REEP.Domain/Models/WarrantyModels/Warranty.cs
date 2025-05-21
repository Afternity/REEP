using REEP.Domain.Models.PassportModels;
using REEP.Domain.Models.ContractModels;
using REEP.Domain.Models.WarrantyModels.WarrantyTypeModels;
using REEP.Domain.InterfaceModels;

namespace REEP.Domain.Models.WarrantyModels
{
    public class Warranty : IAuditable
    {
        public Guid Id { get; set; }
        public string Name {get; set; } = string.Empty;
        public string Description {get; set; } = string.Empty;
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;
        public DateTime? UpdateDate { get; set; }

        public Guid ContractId { get; set; }
        public Contract Contract { get; set; } = null!;
        public Guid WarrantyTypeId { get; set; }
        public WarrantyType WarrantyType { get; set; } = null!;
        public IList<EquipmentPassport> EquipmentPassports { get; set; } = [];
    }
}
