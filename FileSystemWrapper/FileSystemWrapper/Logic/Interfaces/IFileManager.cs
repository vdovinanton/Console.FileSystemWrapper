using System.Collections.Generic;
using System.Threading.Tasks;
using FileSystemWrapper.Common.Enums;

namespace FileSystemWrapper.Logic.Interfaces
{
    public interface IFileManager
    {
        /// <summary>
        /// Gets the name of file, <b>including their path</b>
        /// </summary>
        /// <param name="currentDirctory">Soure folder</param>
        /// <param name="command">Action command, for the current search filter</param>
        Task<List<string>> GetFileNamesAsync(string currentDirctory, AvailableActions command);

        Task SaveAsync(string fileName, string content);
    }
}
