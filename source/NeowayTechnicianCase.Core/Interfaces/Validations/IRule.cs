namespace NeowayTechnicianCase.Core.Interfaces.Validations
{
    public interface IRule<TType> where TType : class
    {
        bool Passes(TType value);
    }
}