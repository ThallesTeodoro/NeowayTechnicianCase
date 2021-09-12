using NeowayTechnicianCase.Core.Interfaces.Validations;

namespace NeowayTechnicianCase.Infrastructure.Validations
{
    public class Validator<TRule, TType> : IValidator<TRule, TType> where TRule : IRule<TType> where TType : class
    {
        public bool Validate(TRule rule, TType value)
        {
            return rule.Passes(value);
        }
    }
}