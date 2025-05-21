using REEP.Domain.Models.PassportModels.PassportTypeModels;
using REEP.Domain.InterfaceModels;

namespace REEP.Domain.Models.PassportModels
{
    public class Status : IAuditable
    {
        public Guid Id { get; set; }
        public bool IsActive { get; set; } = false;
        public DateTime? StartActive { get; set; }
        public DateTime? EndActive { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;
        public DateTime? UpdateDate { get; set; }

        public Guid StatusTypeId { get; set; }
        public StatusType StatusType { get; set; } = null!;
        public IList<EquipmentPassport> EquipmentPassports { get; set; } = [];
    }
}
