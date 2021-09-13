using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using NeowayTechnicianCase.Core.Interfaces.Services;
using NeowayTechnicianCase.Infrastructure.Services;
using NeowayTechnicianCase.Infrastructure.Validations;
using Xunit;

namespace NeowayTechnicianCase.UnitTests
{
    public class FileReadingTest
    {
        [Fact]
        public async Task ReadFile_WhenCalled_ReturnsListOfResources()
        {
            string path = Directory.GetCurrentDirectory() + "/base_teste.txt";

            IFileReading fileReading = new FileReading();

            List<string[]> data = await fileReading.ReadFile(path, new char[] { ' ' }, 1);

            Assert.True(data.Count == 140);
        }
    }
}
