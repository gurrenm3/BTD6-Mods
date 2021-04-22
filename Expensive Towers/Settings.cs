using System.IO;
using static Expensive_Towers.Serializer;

namespace Expensive_Towers
{
    internal class Settings
    {
        private static Settings settings;

        public static Settings LoadedSettings
        {
            get { return (settings != null) ? settings : LoadSettings(); }
            set { settings = value; }
        }

        public static string settingsPath = MelonMain.modDir + "//settings.json";


        // Put the properties you want to save in here
        #region Properties
        public bool ApplyToHeros { get; set; } = true;
        public float CostMultiplier { get; set; } = 2f;
        #endregion


        public static Settings LoadSettings()
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