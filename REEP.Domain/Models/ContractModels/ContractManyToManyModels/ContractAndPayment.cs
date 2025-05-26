﻿using REEP.Domain.InterfaceModels;
using System.ComponentModel.DataAnnotations;

namespace REEP.Domain.Models.ContractModels.ContractManyToManyModels
{
    public class ContractAndPayment : IAuditable, ISoftDeletable
    {
        [Key]
        public Guid ContractId { get; set; }
        public Contract Contract { get; set; } = null!;

        [Key]
        public Guid PaymentId { get; set; }
        public Payment Payment { get; set; } = null!;

        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
