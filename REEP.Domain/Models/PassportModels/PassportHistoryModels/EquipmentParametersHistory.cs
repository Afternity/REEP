namespace REEP.Domain.Models.PassportModels.PassportHistory
{
    public class EquipmentParametersHistory
    {
        public Guid Id { get; set; }
        public DateTime ChangeDate { get; set; } = DateTime.UtcNow;
        public string ChangeReason { get; set; } = "Update";
        public string Comment { get; set; } = string.Empty;

        public string EquipmentPassportNumber { get; set; } = string.Empty;

        public string UserUsedName { get; set; } = string.Empty;
        public string UserGrantAccessName { get; set; } = string.Empty;

        public string EquipmentName { get; set; } = string.Empty;
        public string EquipmentType { get; set; } = string.Empty;

        public string LocationName { get; set; } = string.Empty;

        public string StatusName { get; set; } = string.Empty;
        public bool StatusIsActive { get; set; } 
        public DateTime? StatusStartDate { get; set; }
        public DateTime? StatusEndDate { get; set; }

        public string ParameterDescription { get; set; } = string.Empty;

        public Guid ModifiedByUserId { get; set; }
        public string ModifiedByUserName { get; set; } = string.Empty;

        public Guid? EquipmentPassportId { get; set; }
    }
}
