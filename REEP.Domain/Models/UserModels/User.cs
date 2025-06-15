﻿using REEP.Domain.Models.PassportModels;
using REEP.Domain.Models.UserModels.UserTypeModels;
using REEP.Domain.InterfaceModels;
using REEP.Domain.Models.MaintenanceModels;

namespace REEP.Domain.Models.UserModels
{
    public class User : IAuditable, ISoftDeletable
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string SecondName { get; set; } = string.Empty;
        public string? LastName { get; set; }
        public string Email { get; set; } = string.Empty;
        public string? OtherContacts {  get; set; }
        public string Password { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool IsDeleted { get; set; } = false;

        public Guid UserTypeId { get; set; }
        public UserType UserType { get; set; } = null!;
        public ICollection<EquipmentPassport> UserUsedEquipmentPassports { get; set; } = [];
        public ICollection<EquipmentPassport> UserGrantAccessEquipmentPassports { get; set; } = [];
        public ICollection<MaintenanceRequest> CreatedRequests { get; set; } = [];
        public ICollection<MaintenanceRequest> ApprovedRequests { get; set; } = [];
    }
}
