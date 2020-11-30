using System;
using System.IO;

namespace One_Tower_To_Rule_Them_All
{
    class Settings
    {
        public static Settings settings;
        public static string settingsPath = MelonMain.modDir + "//settings.json";

        public string TowerName { get; set; } = "SuperMonkey";
        public bool UseRandomUpgradesInstead { get; set; } = true;
        public int upgrade1 { get; set; } = 0;
        public int upgrade2 { get; set; } = 0;
        public int upgrade3 { get; set; } = 0;


        public static Settings LoadSettings()
        {
            if (File.Exists(settingsPath))
                settings = Gurren_Core.Utils.JsonSerializer.LoadFromFile<Settings>(settingsPath);
            else
                CreateNewSettingsFile();

            return settings;
        }

        private static void CreateNewSettingsFile()
        {
            settings = new Settings();
            Gurren_Core.Utils.JsonSerializer.SaveToFile<Settings>(settings, settingsPath);
        }
    }
}
