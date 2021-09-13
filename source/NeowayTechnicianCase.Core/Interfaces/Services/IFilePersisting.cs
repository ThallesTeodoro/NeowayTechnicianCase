using System.Collections.Generic;
using System.Threading.Tasks;

namespace NeowayTechnicianCase.Core.Interfaces.Services
{
    public interface IFilePersisting
    {
        /// <summary>
        /// Persist the data in database
        /// </summary>
        /// <param name="data"></param>
        /// <param name="batchSize"></param>
        Task Persist(List<string[]> data);
    }
}