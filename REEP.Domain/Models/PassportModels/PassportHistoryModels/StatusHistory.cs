using REEP.Domain.Models.PassportModels.PassportActionModels;

namespace REEP.Domain.Models.PassportModels.PassportHistoryModels
{
    public class StatusHistory
    {
        public Guid Id { get; set; }
        public DateTime DateOfReceipt { get; set; } = DateTime.Now;

        public Guid StatusId { get; set; }
        public Status Status { get; set; } = null!;
        public Guid StatusActionId { get; set; }
        public StatusAction StatusAction { get; set; } = null!;
    }
}
