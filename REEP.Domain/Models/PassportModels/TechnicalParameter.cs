﻿using REEP.Domain.InterfaceModels;

namespace REEP.Domain.Models.PassportModels
{
    public class TechnicalParameter : IAuditable
    {
        public Guid Id { get; set; }
        public string Parameters { get; set; } = string.Empty;
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;
        public DateTime? UpdateDate { get; set; }

        public IList<Equipment> Equipments { get; set; } = [];
    }
}
