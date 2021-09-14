using System.ComponentModel.DataAnnotations;

namespace NeowayTechnicianCase.Core.Entities
{
    public class Store : BaseEntity
    {
        [StringLength(14)]
        public string CNPJ { get; set; }
        public bool CNPJIsValid { get; set; }
    }
}