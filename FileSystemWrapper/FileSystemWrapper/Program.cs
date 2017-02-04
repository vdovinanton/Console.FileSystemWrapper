using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using FileSystemWrapper.Common;
using FileSystemWrapper.Common.Enums;
using FileSystemWrapper.Logic.Interfaces;

namespace FileSystemWrapper
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var inputPath = "D:\\Demo";
            var inputCommand = AvailableActions.Cpp;

            var container = StartupSetting.Instance.GetBuilder();
            using (var scope = container.BeginLifetimeScope())
            {
                var service = scope.Resolve<IFileService>();

                service.FileScanningProcessAsync(inputPath, inputCommand).Wait();
                Console.WriteLine($"Result was saved to the {StartupSetting.Instance.MyDocumentsDirectory}");
            }
        }
    }
}
