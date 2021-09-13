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

        public override string ToString()
        {
            return String.Format("{0} | {1} | {2} | {3} | {4} | {5} | {6} | {7}",
                CPF,
                Private,
                Unfinished,
                LastPurchase,
                MediumTicket,
                LastPurchaseTicket,
                UsualStore.CNPJ,
                LastStore.CNPJ
            );
        }
    }
}