using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileSystemWrapper.Common.Enums;

namespace FileSystemWrapper.Common
{
    public class StartupSetting
    {
        #region Singletone
        private static readonly Lazy<StartupSetting> _instance = new Lazy<StartupSetting>(() => new StartupSetting());

        public static StartupSetting Instance => _instance.Value;
        #endregion

        private StartupSetting() { }

        public readonly string DefaultFileName = "results.txt";
        public readonly string CppFormatEnding = " /";
        public readonly string MyDocumentsDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        public Dictionary<string, AvailableActions> AvalibleCommands => new Dictionary<string, AvailableActions>
        {
            { "all", AvailableActions.All },
            { "cpp", AvailableActions.Cpp},
            { "reversed1", AvailableActions.Reversed1 },
            { "reversed2", AvailableActions.Reversed2 }
        };
    }
}
