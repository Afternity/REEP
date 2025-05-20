namespace REEP.Domain.Models.PassportModels
{
    public class Location
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;

        public IList<EquipmentPassport> EquipmentPassports { get; set; } = [];
    }
}
