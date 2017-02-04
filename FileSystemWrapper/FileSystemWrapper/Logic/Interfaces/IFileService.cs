using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileSystemWrapper.Common.Enums;

namespace FileSystemWrapper.Logic.Interfaces
{
    public interface IFileService
    {
        string ResultFileName { get; set; }
        Task FileScanningProcessAsync(string directoryPath, AvailableActions command);
    }
}
