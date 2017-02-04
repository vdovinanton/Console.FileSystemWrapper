﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
