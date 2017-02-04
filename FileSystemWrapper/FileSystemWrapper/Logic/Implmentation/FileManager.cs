using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FileSystemWrapper.Common;
using FileSystemWrapper.Common.Enums;
using FileSystemWrapper.Logic.Interfaces;

namespace FileSystemWrapper.Logic.Implmentation
{
    public class FileManager: IFileManager
    {
        public async Task<List<string>> GetFileNamesAsync(string currentDirctory, AvailableActions command)
        {
            var fileFilter = command == AvailableActions.Cpp
                ? $"*.{StartupSetting.Instance.AvalibleCommands.FirstOrDefault(q => q.Value == AvailableActions.Cpp).Key}"
                : "*.*";

            var result = Task.Factory.StartNew(() => Directory.GetFiles(currentDirctory, fileFilter, SearchOption.AllDirectories).ToList());
            return await result;
        }

        public async Task SaveAsync(string fileName, string content)
        {            
            await Task.Factory.StartNew(() => File.AppendAllText(!fileName.EndsWith(".txt") ? fileName + ".txt" : fileName, content + Environment.NewLine));
        }
    }
}
