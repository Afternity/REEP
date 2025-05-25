using REEP.Domain.InterfaceModels;

namespace REEP.Domain.Models.UserModels.UserTypeModels
{
    public class UserType : IAuditable, ISoftDeletable
    {
        public Guid Id { get; set; }
        public string Type { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool IsDeleted { get; set; } = false;

        public ICollection<User> Users { get; set; } = [];
    }
}
