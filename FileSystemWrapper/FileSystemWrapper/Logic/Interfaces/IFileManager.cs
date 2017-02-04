using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileSystemWrapper.Common.Enums;

namespace FileSystemWrapper.Logic.Interfaces
{
    public interface IFileManager
    {
        Task<List<string>> GetFileNamesAsync(string currentDirctory, AvailableActions command);

        Task SaveAsync(string fileName, string content);
    }
}
