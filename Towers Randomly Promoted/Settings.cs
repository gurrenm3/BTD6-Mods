using System.IO;
using static Towers_Randomly_Promoted.Serializer;

namespace Towers_Randomly_Promoted
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
        public bool WorkInSandbox { get; set; } = false;
        public bool AllowPromoteToDifferentTower { get; set; } = true;
        public int MinTimeToPromotion { get; set; } = 30;
        public int MaxTimeToPromotion { get; set; } = 60;
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