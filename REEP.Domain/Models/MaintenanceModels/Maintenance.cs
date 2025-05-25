﻿using REEP.Domain.Models.MaintenanceModels.MaintenanceHistoryModels;
using REEP.Domain.Models.MaintenanceModels.MaintenanceTypeModels;
using REEP.Domain.InterfaceModels;

namespace REEP.Domain.Models.MaintenanceModels
{
    public class Maintenance : IAuditable
    {
        public Guid Id { get; set; }
        public bool IsActive { get; set; } = false;
        public string TotalDescription { get; set; } = string.Empty;
        public DateTime? DateOfStart { get; set; }
        public TimeSpan? PossibleRepairTime { get; set; }
        public DateTime? DateOfEnd { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

        public Guid MaintenanceTypeId { get; set; }
        public MaintenanceType MaintenanceType { get; set; } = null!;
        public ICollection<MaintenаnceParametersHistory> HistoryRecords { get; set; } = [];
        public ICollection<MaintenanceRequest> MaintenanceRequests { get; set; } = [];
    }
}
