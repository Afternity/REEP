using REEP.Domain.InterfaceModels;

namespace REEP.Domain.Models.PassportModels
{
    public class TechnicalParameter : IAuditable
    {
        public Guid Id { get; set; }
        public string Parameters { get; set; } = "{}";
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

        public ICollection<Equipment> Equipments { get; set; } = [];
    }
}
