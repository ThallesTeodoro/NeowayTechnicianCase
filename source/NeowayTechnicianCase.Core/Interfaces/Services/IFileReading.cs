using System.Collections.Generic;
using System.Threading.Tasks;

namespace NeowayTechnicianCase.Core.Interfaces.Services
{
    public interface IFileReading
    {
        /// <summary>
        /// Read the text file
        /// </summary>
        /// <param name="path"></param>
        /// <param name="delimiter"></param>
        /// <param name="skip"></param>
        /// <returns>A list of Porchase read from the file</returns>
        Task<List<string[]>> ReadFile(string path, char[] delimiter, int skip = 1);
    }
}