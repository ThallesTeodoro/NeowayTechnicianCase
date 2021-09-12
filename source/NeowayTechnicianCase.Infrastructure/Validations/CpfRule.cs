using System.Text.RegularExpressions;
using NeowayTechnicianCase.Core.Interfaces.Validations;

namespace NeowayTechnicianCase.Infrastructure.Validations
{
    public class CpfRule : IRule<string>
    {
        /// <summary>
        /// Check if the value is a valid CPF
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Boolean</returns>
        public bool Passes(string value)
        {
            value = value.Trim()
                .Replace(".", "")
                .Replace("-", "");

            if (value.Length != 11)
            {
                return false;
            }

            if (Regex.IsMatch(value, "^" + int.Parse(value[0].ToString()) + "{11}$", RegexOptions.IgnoreCase))
            {
                return false;
            }

            int multiplier = 10;
            int sum = 0;

            for (int i = 0; multiplier >= 2; sum += int.Parse(value[i++].ToString()) * multiplier--);

            sum = sum % 11;
            sum = sum < 2 ? 0 : 11 - sum;

            if (int.Parse(value[9].ToString()) != sum)
            {
                return false;
            }

            multiplier = 11;
            sum = 0;

            for (int i = 0; multiplier >= 2; sum += int.Parse(value[i++].ToString()) * multiplier--);

            sum = sum % 11;
            sum = sum < 2 ? 0 : 11 - sum;

            if (int.Parse(value[10].ToString()) != sum)
            {
                return false;
            }

            return true;
        }
    }
}