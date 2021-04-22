using System.IO;
using static Infinite_Hypersonic_Range.Serializer;

namespace Infinite_Hypersonic_Range
{
    internal class Settings
    {
        public static string settingsPath = MelonMain.modDir + "//settings.json";
        
        private static Settings settings;
        public static Settings LoadedSettings
        {
            get { return (settings != null) ? settings : Load(); }
            set { settings = value; }
        }




        // Put the properties you want to save in here
        #region Properties
        public bool EnableInfiniteRange { get; set; } = true;
        public float DivideAttackSpeedBy { get; set; } = 0;
        #endregion


        public static Settings Load()
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