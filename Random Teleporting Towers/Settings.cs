using System.IO;
using static Random_Teleporting_Towers.Serializer;

namespace Random_Teleporting_Towers
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
        public bool TeleportAfterTime { get; set; } = true;
        public int MinTimeBeforeTeleport { get; set; } = 5;
        public int MaxTimeBeforeTeleport { get; set; } = 30;
        public bool TeleportAfterRounds { get; set; } = false;
        public int RoundsBeforeTeleport { get; set; } = 5;
        public bool WorkInSandbox { get; set; } = false;
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