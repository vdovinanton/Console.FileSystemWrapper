using System;
using System.Linq;
using FileSystemWrapper.Logic.Interfaces;

namespace FileSystemWrapper.Logic.Implmentation.FileActions
{
    public class ReverseBFilePath: IFileAction
    {
        public string Execute(string path)
        {
            if (string.IsNullOrEmpty(path)) throw new ArgumentNullException();

            return new string(path.Reverse().ToArray());
        }
    }
}
