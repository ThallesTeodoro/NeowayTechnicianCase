namespace NeowayTechnicianCase.Core.Entities
{
    public class Store : BaseEntity
    {
        public string CNPJ { get; set; }
        public bool CNPJIsValid { get; set; }
    }
}