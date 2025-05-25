using REEP.Domain.InterfaceModels;

namespace REEP.Domain.Models.UserModels.UserTypeModels
{
    public class UserType : IAuditable
    {
        public Guid Id { get; set; }
        public string Type { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

        public ICollection<User> Users { get; set; } = [];
    }
}
