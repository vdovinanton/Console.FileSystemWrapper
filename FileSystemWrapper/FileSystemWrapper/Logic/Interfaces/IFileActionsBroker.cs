using FileSystemWrapper.Common.Enums;

namespace FileSystemWrapper.Logic.Interfaces
{
    public interface IFileActionsBroker
    {
        /// <param name="command"></param>
        /// <returns>Returned current <see cref="IFileAction"/> by <see cref="AvailableActions"/></returns>
        IFileAction GetCurrentActionType(AvailableActions command);
    }
}
