using System.Collections.Generic;
using System.IO;
using static Random_Towers.Serializer;

namespace Random_Towers
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
        public bool RandomizeTowerEvery_X_Rounds { get; set; } = false;
        public int NumOfRoundsBeforeRandomize { get; set; } = 5;
        public bool RandomizeTowerWhenPlaced { get; set; } = true;
        public bool AllowRandomUpgrades { get; set; } = true;
        public int MaxRandomUpgrade { get; set; } = 5;
        public int MinimumRandomTier { get; set; } = 0;
        public List<string> AllowedTowers { get; set; } = new List<string>();
        #endregion


        public static Settings LoadSettings()
        {
            settings = (File.Exists(settingsPath)) ? LoadFromFile<Settings>(settingsPath) : CreateNewSettingsFile();
            return settings;
        }

        private static Settings CreateNewSettingsFile()
        {
            var settings = new Settings();
            settings.Save();
            return settings;
        }

        public void Save()
        {
            SaveToFile<Settings>(settings, settingsPath);
        }
    }
}