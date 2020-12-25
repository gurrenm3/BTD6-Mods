using System.IO;
using static One_Tower_To_Rule_Them_All.Serializer;

namespace One_Tower_To_Rule_Them_All
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
        public string TowerName { get; set; } = "SuperMonkey";
        public bool UseRandomUpgradesInstead { get; set; } = true;
        public int upgrade1 { get; set; } = 0;
        public int upgrade2 { get; set; } = 0;
        public int upgrade3 { get; set; } = 0;
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