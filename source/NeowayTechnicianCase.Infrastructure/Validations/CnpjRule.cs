using System.Text.RegularExpressions;
using NeowayTechnicianCase.Core.Interfaces.Validations;

namespace NeowayTechnicianCase.Infrastructure.Validations
{
    public class CnpjRule : IRule<string>
    {
        /// <summary>
        /// Check if the value is a valid CNPJ
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Passes(string value)
        {
            value = value.Trim()
                .Replace(".", "")
                .Replace("-", "")
                .Replace("/", "");

            if (value.Length != 14)
            {
                return false;
            }

            if (Regex.IsMatch(value, "^" + int.Parse(value[0].ToString()) + "{14}$", RegexOptions.IgnoreCase))
            {
                return false;
            }

            int[] multiplier = new int[13] {6,5,4,3,2,9,8,7,6,5,4,3,2};

            int sum = 0;

            for (int i = 0; i < 12; sum += int.Parse(value[i].ToString()) * multiplier[++i]);

            sum = sum % 11;
            sum = sum < 2 ? 0 : 11 - sum;

            if (int.Parse(value[12].ToString()) != sum)
            {
                return false;
            }

            sum = 0;
            for (int i = 0; i <= 12; sum += int.Parse(value[i].ToString()) * multiplier[i++]);

            sum = sum % 11;
            sum = sum < 2 ? 0 : 11 - sum;

            if (int.Parse(value[13].ToString()) != sum)
            {
                return false;
            }

            return true;
        }
    }
}