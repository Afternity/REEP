using REEP.Domain.InterfaceModels;
using REEP.Domain.Models.PassportModels.PassportTypeModels;

namespace REEP.Domain.Models.PassportModels
{
    public class Equipment : IAuditable
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;
        public DateTime? UpdateDate { get; set; }

        public Guid EquipmentTypeId { get; set; }
        public EquipmentType EquipmentType { get; set; } = null!;
        public Guid TechnicalParameterId { get; set; }
        public TechnicalParameter? TechnicalParameter { get; set; } = null!;
        public ICollection<EquipmentPassport> EquipmentPassports { get; set; } = [];
    }
}
