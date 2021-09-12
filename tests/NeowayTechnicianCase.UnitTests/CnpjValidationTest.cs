using System.Collections.Generic;
using NeowayTechnicianCase.Infrastructure.Validations;
using Xunit;

namespace NeowayTechnicianCase.UnitTests
{
    public class CnpjValidationTest
    {
        [Fact]
        public void CnpjRule_WhenCalledWithInvalidValues_ReturnsFalse()
        {
            List<string> invalidCnpjs = new List<string>()
            {
                "80.688.960/0001-21", "09.411.817/0001-29", "68.111.842/0001-00",
                "27.868.204/0001-01", "59.979.655/0001-09", "98.146.418/0001-00",
                "20.268.085/0001-01", "63.816.060/0001-09", "56.480.204/0001-00",
                "40.635.621/0001-61", "70.734.693/0001-29", "21.873.992/0001-00",
                "20.737.126/0001-51", "53.250.013/0001-89", "89.769.826/0001-00",
            };

            CnpjRule validator = new CnpjRule();

            foreach (string cnpj in invalidCnpjs)
            {
                Assert.False(validator.Passes(cnpj), cnpj);
            }
        }

        [Fact]
        public void CnpjRule_WhenCalled_ReturnsTrue()
        {
            List<string> invalidCnpjs = new List<string>()
            {
                "80.688.960/0001-25", "09.411.817/0001-27", "68.111.842/0001-54",
                "27.868.204/0001-03", "59.979.655/0001-04", "98.146.418/0001-06",
                "20.268.085/0001-09", "63.816.060/0001-05", "56.480.204/0001-21",
                "40.635.621/0001-66", "70.734.693/0001-21", "21.873.992/0001-31",
                "20.737.126/0001-50", "53.250.013/0001-85", "89.769.826/0001-23",
            };

            CnpjRule validator = new CnpjRule();

            foreach (string cnpj in invalidCnpjs)
            {
                Assert.True(validator.Passes(cnpj), cnpj);
            }
        }
    }
}