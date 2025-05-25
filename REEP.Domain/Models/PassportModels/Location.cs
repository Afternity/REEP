﻿using REEP.Domain.InterfaceModels;

namespace REEP.Domain.Models.PassportModels
{
    public class Location : IAuditable
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public string? Address { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt{ get; set; }

        public ICollection<EquipmentPassport> EquipmentPassports { get; set; } = [];
    }
}
