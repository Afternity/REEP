using REEP.Domain.Models.PassportModels;
using REEP.Domain.Models.UserModels.UserTypeModels;

namespace REEP.Domain.Models.UserModels
{
    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string SecondName { get; set; } = string.Empty;
        public string? LastName { get; set; }
        public string Email { get; set; } = string.Empty;
        public string? OtherContacts {  get; set; }
        public byte[] PasswordHash { get; set; } = new byte[32];
        public byte[] PasswordSalt { get; set; } = new byte[32];

        public Guid UserTypeId { get; set; }
        public UserType UserType { get; set; } = null!;
        public IList<EquipmentPassport> EquipmentPassports { get; set; } = [];
    }
}
