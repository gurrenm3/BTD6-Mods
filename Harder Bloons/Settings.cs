using System.IO;
using static Harder_Bloons.Serializer;

namespace Harder_Bloons
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
        public bool UseRandomlyStrongerBloons { get; set; } = true;
        public bool RandomizeBloonsEveryRound { get; set; } = false;
        public int ChanceForRandomStrongerBloons { get; set; } = 8;
        public int maxRandomChange { get; set; } = 4;
        public bool AllowRandomCamos { get; set; } = true;
        public bool AllowRandomRegrows { get; set; } = true;
        public bool AllowRandomFortified { get; set; } = true;

        public bool ForceAllBloonsCamo { get; set; } = false;
        public bool ForceAllBloonsRegrow { get; set; } = false;
        public bool ForceAllBloonsFortified { get; set; } = false;
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