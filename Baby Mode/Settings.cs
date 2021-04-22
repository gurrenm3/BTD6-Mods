using System.IO;
using static Baby_Mode.Serializer;

namespace Baby_Mode
{
    internal class Settings
    {
        private static Settings settings;

        public static Settings LoadedSettings
        {
            get { return (settings != null) ? settings : Load(); }
            set { settings = value; }
        }

        public static string settingsPath = MelonMain.modDir + "//settings.json";


        // Put the properties you want to save in here
        #region Properties
        public bool ApplyToHeros { get; set; } = true;
        public bool AllowCamo { get; set; } = false;
        public bool AllowRegrow { get; set; } = false;
        public bool AllowFortified { get; set; } = false;
        #endregion


        public static Settings Load()
        {
            settings = (File.Exists(settingsPath)) ? LoadFromFile<Settings>(settingsPath) : CreateNewSettingsFile();
            return settings;
        }

        private static Settings CreateNewSettingsFile()
        {
            var settings = new Settings();
            SaveToFile<Settings>(settings, settingsPath);
            return settings;
        }
    }
}