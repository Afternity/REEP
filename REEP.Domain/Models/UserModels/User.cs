using REEP.Domain.Models.PassportModels;
using REEP.Domain.Models.UserModels.UserTypeModels;
using REEP.Domain.InterfaceModels;
using REEP.Domain.Models.MaintenanceModels;

namespace REEP.Domain.Models.UserModels
{
    public class User : IAuditable
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string SecondName { get; set; } = string.Empty;
        public string? LastName { get; set; }
        public string Email { get; set; } = string.Empty;
        public string? OtherContacts {  get; set; }
        public byte[] PasswordHash { get; set; } = new byte[32];
        public byte[] PasswordSalt { get; set; } = new byte[32];
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;
        public DateTime? UpdateDate { get; set; }

        public Guid UserTypeId { get; set; }
        public UserType UserType { get; set; } = null!;
        public IList<EquipmentPassport> EquipmentPassports { get; set; } = [];
        public IList<MaintenanceRequest> CreatedRequests { get; set; } = [];
        public IList<MaintenanceRequest> ApprovedRequests { get; set; } = [];
    }
}
