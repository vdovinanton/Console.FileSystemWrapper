using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileSystemWrapper.Common.Enums;
using FileSystemWrapper.Logic.Interfaces;

namespace FileSystemWrapper.Logic.Implmentation
{
    public class FileService: IFileService
    {
        public string ResultFileName { get; set; }
        public Task FileScanningProcessAsync(string directoryPath, AvailableActions command)
        {
            throw new NotImplementedException();
        }
    }
}
