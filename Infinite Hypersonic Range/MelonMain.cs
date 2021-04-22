using Assets.Scripts.Unity;
using Assets.Scripts.Unity.UI_New.InGame;
using MelonLoader;
using System;
using System.IO;
using System.Reflection;

namespace Infinite_Hypersonic_Range
{
    public class MelonMain : MelonMod
    {
        internal static string modDir = $"{Environment.CurrentDirectory}\\Mods\\{Assembly.GetExecutingAssembly().GetName().Name}";

        public override void OnApplicationStart()
        {
            MelonLogger.Log("Mod has finished loading");

            string modName = Assembly.GetExecutingAssembly().GetName().Name;
            MelonLogger.Log($"{modName} will not work in Races, Odyssey, and Public Co-op matches. This is for your own" +
                $" protection so you're account doesn't get in trouble.");
        }

        public override void OnUpdate()
        {
            if (Game.instance is null)
                return;

            WriteReadme();

            if (InGame.instance is null)
                return;

        }

        private void WriteReadme()
        {
            string readmeFilePath = modDir + "/readme.txt";

            if (File.Exists(readmeFilePath))
                return;

            Directory.CreateDirectory(modDir);

            string text = "To make towers hypersonic, set DivideAttackSpeedBy to 0. To make them faster, set DivideAttackSpeedBy to be the number" +
                " you want to divide the default attack speed by. For example, setting it to 3 would make attack speeed delay divided by 3, or" +
                " one third of the normal delay";

            File.WriteAllText(readmeFilePath, text);
            MelonLogger.Log("A readme was created for Infinite Hypersonic Towers. Check \"Bloons TD6/Mods/Infinite Hypersonic Towers/readme.txt\"" +
                " to learn how to adjust the settings for the mod.");
        }
    }
}