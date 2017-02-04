using System;
using FileSystemWrapper.Logic.Interfaces;

namespace FileSystemWrapper.Logic.Implmentation.FileActions
{
    public class PathShift: IFileAction
    {
        public string Execute(string path)
        {
            if (string.IsNullOrEmpty(path)) throw new ArgumentNullException();

            return path;
        }
    }
}
