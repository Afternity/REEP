using REEP.Domain.Models.PassportModels;
using REEP.Domain.Models.ContractModels;

namespace REEP.Domain.Models.WarrantyModels
{
    public class Warranty
    {
        public Guid Id { get; set; }
        public string Name {get; set; } = string.Empty;
        public string Description {get; set; } = string.Empty;
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public Guid ContractId { get; set; }
        public Contract Contract { get; set; } = null!;
        public IList<EquipmentPassport> EquipmentPassports { get; set; } = [];
    }
}
