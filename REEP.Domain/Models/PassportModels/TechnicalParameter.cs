using REEP.Domain.InterfaceModels;

namespace REEP.Domain.Models.PassportModels
{
    public class TechnicalParameter : IAuditable, ISoftDeletable
    {
        public Guid Id { get; set; }
        public string Parameters { get; set; } = "{}";
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool IsDeleted { get; set; } = false;

        public ICollection<Equipment> Equipments { get; set; } = [];
    }
}
