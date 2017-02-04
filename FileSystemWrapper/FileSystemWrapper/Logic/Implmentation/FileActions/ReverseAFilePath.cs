using System;
using System.Linq;
using FileSystemWrapper.Logic.Interfaces;

namespace FileSystemWrapper.Logic.Implmentation.FileActions
{
    public class ReverseAFilePath: IFileAction
    {
        public string Execute(string path)
        {
            if (string.IsNullOrEmpty(path)) throw new ArgumentNullException();

            return string.Join("\\", path.Split('\\').Reverse());
        }
    }
}
