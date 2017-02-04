using System;
using System.IO;
using Autofac;
using FileSystemWrapper.Common;
using FileSystemWrapper.Logic.Interfaces;

namespace FileSystemWrapper
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var destFileName = StartupSetting.Instance.MyDocumentsDirectory;
            if (!Validate(args))
            {
                Console.ReadKey();
                return;
            }
            if (args.Length == 3)
                destFileName = args[2];

            var container = StartupSetting.Instance.GetBuilder();
            using (var scope = container.BeginLifetimeScope())
            {
                var service = scope.Resolve<IFileService>();
                service.ResultFileName = destFileName;
                service.FileProcessAsync(args[0], StartupSetting.Instance.AvalibleCommands[args[1].ToLower()]).Wait();
                Console.WriteLine($"Result was saved to the {destFileName}");
            }
        }

        private static bool Validate(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Missed input parameters");
                return false;
            }
            if (!Directory.Exists(args[0]))
            {
                Console.WriteLine("Directory path non-valid or can not be read");
            }

            if (StartupSetting.Instance.AvalibleCommands.ContainsKey(args[1].ToLower())) return true;
            Console.WriteLine("Action name must be one of: all, cpp, reversed1, reversed2");
            return false;
        }
    }
}
