using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemWrapper.Logic.Interfaces
{
    public interface IFileAction
    {
        string Execute(string path);
    }
}
