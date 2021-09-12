namespace NeowayTechnicianCase.Core.Interfaces.Validations
{
    public interface IValidator<TRule, TType> where TRule : IRule<TType> where TType : class
    {
        bool Validate(TRule rule, TType value);
    }
}