using REEP.Domain.Models.PassportModels.PassportTypeModels;

namespace REEP.Domain.Models.PassportModels
{
    public class Status
    {
        public Guid Id { get; set; }
        public bool IsActive { get; set; } = false;
        public DateTime? StartActive { get; set; }
        public DateTime? EndActive { get; set; }
        
        public Guid StatusTypeId { get; set; }
        public StatusType StatusType { get; set; } = null!;
        public IList<EquipmentPassport> EquipmentPassports { get; set; } = [];
    }
}
