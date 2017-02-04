using System.Linq;
using System.Threading.Tasks;
using FileSystemWrapper.Common;
using FileSystemWrapper.Common.Enums;
using FileSystemWrapper.Logic.Interfaces;

namespace FileSystemWrapper.Logic.Implmentation
{
    public class FileService: IFileService
    {
        private readonly IFileManager _fileManager;
        private readonly IFileActionsBroker _actionBroker;
        private string _fileName;

        public FileService(IFileManager fileManager, IFileActionsBroker actionBroker)
        {
            _fileManager = fileManager;
            _actionBroker = actionBroker;
        }

        public string ResultFileName
        {
            get { return string.IsNullOrEmpty(_fileName) ? StartupSetting.Instance.MyDocumentsDirectory : _fileName; }
            set { _fileName = value; }
        }

        public async Task FileProcessAsync(string directoryPath, AvailableActions command)
        {
            var currentFileAction = _actionBroker.GetCurrentActionType(command);
            var files = await _fileManager.GetFileNamesAsync(directoryPath, command);

            if (files != null && files.Any())
            {
                var formattedFiles = files.Select(q => currentFileAction.Execute(q)).ToList();

                foreach (var content in formattedFiles)
                    await _fileManager.SaveAsync(ResultFileName, content);
            }
        }
    }
}
