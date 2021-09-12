using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NeowayTechnicianCase.Core.Entities
{
    public class Purchase : BaseEntity
    {
        public string CPF { get; set; }
        public bool CPFIsValid { get; set; }
        public bool Private { get; set; }
        public bool Unfinished { get; set; }
        public DateTime? LastPurchase { get; set; }
        public double? MediumTicket { get; set; }
        public double? LastPurchaseTicket { get; set; }
        public Guid? UsualStoreId { get; set; }
        public Guid? LastStoreId { get; set; }

        [ForeignKey("UsualStoreId")]
        public virtual Store UsualStore { get; set; }
        [ForeignKey("LastStoreId")]
        public virtual Store LastStore { get; set; }
    }
}