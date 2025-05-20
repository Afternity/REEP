using REEP.Domain.Models.PassportModels.PassportTypeModels;

namespace REEP.Domain.Models.PassportModels
{
    public class Equipment
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public Guid EquipmentTypeId { get; set; }
        public EquipmentType EquipmentType { get; set; } = null!;
        public Guid TechnicalParameterId { get; set; }
        public TechnicalParameter? TechnicalParameter { get; set; } = null!;
        public IList<EquipmentPassport> EquipmentPassports { get; set; } = [];
    }
}
