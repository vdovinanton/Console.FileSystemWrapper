using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileSystemWrapper.Common.Enums;
using FileSystemWrapper.Logic.Interfaces;

namespace FileSystemWrapper.Logic.Implmentation
{
    public class FileManager: IFileManager
    {
        public Task<List<string>> GetFileNamesAsync(string currentDirctory, AvailableActions command)
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync(string fileName, string content)
        {
            throw new NotImplementedException();
        }
    }
}
