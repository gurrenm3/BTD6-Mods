namespace Harder_Bloons
{
    using System.IO;

    public class Settings
    {
        public static Settings settings;
        public static string settingsPath = MelonMain.modDir + "//settings.json";

        public bool UseRandomlyStrongerBloons { get; set; } = true;
        public int ChanceForRandomStrongerBloons { get; set; } = 8;
        public int maxRandomChange { get; set; } = 4;
        public bool AllowRandomCamos { get; set; } = true;
        public bool AllowRandomRegrows { get; set; } = true;
        public bool AllowRandomFortified { get; set; } = true;

        public bool ForceAllBloonsCamo { get; set; } = false;
        public bool ForceAllBloonsRegrow { get; set; } = false;
        public bool ForceAllBloonsFortified { get; set; } = false;


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