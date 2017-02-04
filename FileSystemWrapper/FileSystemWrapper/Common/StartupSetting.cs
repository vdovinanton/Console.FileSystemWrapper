using System;
using System.Collections.Generic;
using Autofac;
using FileSystemWrapper.Common.Enums;
using FileSystemWrapper.Logic.Implmentation;
using FileSystemWrapper.Logic.Interfaces;

namespace FileSystemWrapper.Common
{
    public class StartupSetting
    {
        #region Singletone
        private static readonly Lazy<StartupSetting> _instance = new Lazy<StartupSetting>(() => new StartupSetting());

        public static StartupSetting Instance => _instance.Value;
        #endregion

        private StartupSetting() { }

        public readonly string CppFormatEnding = " /";
        public readonly string MyDocumentsDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\results";

        public Dictionary<string, AvailableActions> AvalibleCommands => new Dictionary<string, AvailableActions>
        {
            { "all", AvailableActions.All },
            { "cpp", AvailableActions.Cpp},
            { "reversed1", AvailableActions.Reversed1 },
            { "reversed2", AvailableActions.Reversed2 }
        };

        public IContainer GetBuilder()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<FileManager>().As<IFileManager>();
            builder.RegisterType<FileActionBroker>().As<IFileActionsBroker>();
            builder.RegisterType<FileService>().As<IFileService>();

            return builder.Build();
        }
    }
}
