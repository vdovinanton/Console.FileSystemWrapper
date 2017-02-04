using System.Threading.Tasks;
using FileSystemWrapper.Common.Enums;

namespace FileSystemWrapper.Logic.Interfaces
{
    public interface IFileService
    {
        /// <summary>
        /// By default has <c>MyDocuments</c>
        /// </summary>
        string ResultFileName { get; set; }

        /// <summary>
        /// Search files in the directory by the filter, after 
        /// formatted save to file
        /// </summary>
        /// <param name="directoryPath">Source folder</param>
        /// <param name="command">Action command</param>
        Task FileProcessAsync(string directoryPath, AvailableActions command);
    }
}
