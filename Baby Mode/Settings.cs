using System;
using System.IO;

namespace Baby_Mode
{
    public class Settings
    {
        public static Settings settings;
        public static string settingsPath = MelonMain.modDir + "//settings.json";

        public bool ApplyToHeros { get; set; } = true;
        public bool AllowCamo { get; set; } = false;
        public bool AllowRegrow { get; set; } = false;
        public bool AllowFortified { get; set; } = false;

        
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
