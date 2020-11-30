using System.Reflection;
using System;
using System.IO;

namespace InfiniteHypersonicRange
{
    public class Settings
    {
        public static Settings settings;
        public static string settingsPath = MelonMain.modDir +"//settings.json";

        public bool EnableInfiniteRange { get; set; } = true;
        public float DivideAttackSpeedBy { get; set; } = 0;


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
