namespace REEP.Domain.Models.PassportModels
{
    public class TechnicalParameter
    {
        public Guid Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public IList<Equipment> Equipments { get; set; } = [];
    }
}
