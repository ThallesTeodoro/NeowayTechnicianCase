using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using NeowayTechnicianCase.Core.Interfaces.Services;

namespace NeowayTechnicianCase.Infrastructure.Services
{
    public class FileReading : IFileReading
    {
        /// <summary>
        /// Read the text file
        /// </summary>
        /// <param name="path"></param>
        /// <param name="delimiter"></param>
        /// <param name="skip"></param>
        /// <returns>A list of Porchase read from the file</returns>
        public async Task<List<string[]>> ReadFile(string path, char[] delimiter, int skip = 1)
        {
            List<string[]> items = new List<string[]>();

            using (var file = new StreamReader(path))
            {
                string line;
                int count = 1;
                while ((line = await file.ReadLineAsync()) != null)
                {
                    if (count > skip)
                    {
                        string[] segments = line.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);
                        items.Add(segments);
                    }
                    else
                    {
                        count++;
                    }
                }

                file.Close();
            }

            return items;
        }
    }
}