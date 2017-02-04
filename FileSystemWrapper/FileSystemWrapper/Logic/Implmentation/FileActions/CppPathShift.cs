using System;
using FileSystemWrapper.Common;
using FileSystemWrapper.Logic.Interfaces;

namespace FileSystemWrapper.Logic.Implmentation.FileActions
{
    public class CppPathShift: IFileAction
    {
        public string Execute(string path)
        {
            if (string.IsNullOrEmpty(path)) throw new ArgumentNullException();

            return path + StartupSetting.Instance.CppFormatEnding;
        }
    }
}
