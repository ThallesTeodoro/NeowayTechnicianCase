using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using NeowayTechnicianCase.Core.Entities;
using NeowayTechnicianCase.Core.Interfaces.Services;
using NeowayTechnicianCase.Infrastructure.Data;
using Xunit;

namespace NeowayTechnicianCase.IntegrationTests
{
    public class FileReadingPersistingTest : IntegrationTestBase
    {
        [Fact]
        public async Task FileReadingPersisting()
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<ApplicationDbContext>();

                IFileReading fileReading = scopedServices.GetRequiredService<IFileReading>();
                IFilePersisting filePersisting = scopedServices.GetRequiredService<IFilePersisting>();

                string path = Directory.GetCurrentDirectory() + "/base_teste.txt";

                List<string[]> data = await fileReading.ReadFile(path, @"[ ]{1,}", 1);
                await filePersisting.Persist(data);

                Assert.True(db.Purchases.Count() == 140);
                int storeCount = db.Stores.Count();
                Assert.True(db.Stores.Count() == 2);

                List<Purchase> purchases = db.Purchases.ToList();
                foreach (Purchase item in purchases)
                {
                    string cleanCpf = item.CPF
                        .Replace(".", "")
                        .Replace("-", "");

                    Assert.True(cleanCpf == item.CPF);

                    string[] itemFileData = data.Where(d => d[0].Replace(".", "").Replace("-", "") == cleanCpf).FirstOrDefault();

                    if (item.UsualStore != null)
                    {
                        Assert.True(itemFileData[6]
                            .Replace(".", "")
                            .Replace("-", "")
                            .Replace("/", "") == item.UsualStore.CNPJ);
                    }

                    if (item.LastStore != null)
                    {
                        Assert.True(itemFileData[7]
                            .Replace(".", "")
                            .Replace("-", "")
                            .Replace("/", "") == item.LastStore.CNPJ);
                    }
                }
            }
        }
    }
}
