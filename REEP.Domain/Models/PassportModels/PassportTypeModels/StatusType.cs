using REEP.Domain.InterfaceModels;

namespace REEP.Domain.Models.PassportModels.PassportTypeModels
{
    public class StatusType : IAuditable
    {
        public Guid Id { get; set; }
        public string Type {  get; set; } = string.Empty;
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;
        public DateTime? UpdateDate { get; set; }

        public IList<Status> Statuses { get; set; } = [];
    }
}
