using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileSystemWrapper.Common.Enums;
using FileSystemWrapper.Logic.Implmentation.FileActions;
using FileSystemWrapper.Logic.Interfaces;

namespace FileSystemWrapper.Logic.Implmentation
{
    public class FileActionBroker: IFileActionsBroker
    {
        private readonly IDictionary<AvailableActions, IFileAction> _fileActions;

        public FileActionBroker()
        {
            _fileActions = new Dictionary<AvailableActions, IFileAction>
            {
                { AvailableActions.All, new PathShift() } ,
                { AvailableActions.Cpp, new CppPathShift() },
                { AvailableActions.Reversed1, new ReverseAFilePath() },
                { AvailableActions.Reversed2, new ReverseBFilePath() }
            };
        }

        public IFileAction GetCurrentActionType(AvailableActions command) => _fileActions[command];
    }
}
