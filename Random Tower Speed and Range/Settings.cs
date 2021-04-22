using System.IO;
using static Random_Tower_Speed_and_Range.Serializer;

namespace Random_Tower_Speed_and_Range
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
        public int ChanceForOP { get; set; } = 30;
        public int ChanceForBalanced { get; set; } = 45;
        public int ChanceForTrash { get; set; } = 25;

        public bool EnableRandomRange { get; set; } = false;
        public int MinRandomRange { get; set; } = 25;
        public int MaxRandomRange { get; set; } = 500;

        public bool EnableRandomSpeed { get; set; } = false;
        public int MinSpeedDelay { get; set; } = 0;
        public int MaxSpeedDelay { get; set; } = 10;
        public int NumRoundsBeforeRandom { get; set; } = 5;
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