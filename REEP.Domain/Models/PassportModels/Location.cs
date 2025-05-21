using REEP.Domain.InterfaceModels;

namespace REEP.Domain.Models.PassportModels
{
    public class Location : IAuditable
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;
        public DateTime? UpdateDate { get; set; }

        public IList<EquipmentPassport> EquipmentPassports { get; set; } = [];
    }
}
