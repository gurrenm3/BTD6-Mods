using Assets.Scripts.Models.Towers.Weapons;
using Assets.Scripts.Simulation.Towers.Weapons;
using Assets.Scripts.Unity;
using Assets.Scripts.Unity.UI_New.InGame;
using Gurren_Core.Logging;
using Il2CppSystem.Collections.Generic;
using Il2CppSystem.IO;
using System.Reflection;
using MelonLoader;
using System;

namespace InfiniteHypersonicRange
{
    public class MelonMain : MelonMod
    {
        internal static string modDir = Environment.CurrentDirectory + "//Mods//" + Assembly.GetExecutingAssembly().GetName().Name;
        internal static bool isInRace = false;
        internal static bool shownInGameMsg = false;

        public override void OnApplicationStart()
        {
            base.OnApplicationStart();

            WriteReadme();

            MelonLogger.Log("Mod has finished loading");
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            if (Game.instance == null || InGame.instance == null)
                return;

            if (isInRace)
            {
                if (!shownInGameMsg)
                {
                    Logger.ShowMessage("Notice! Infinite Hypersonic Range is disabled in Races because it's cheating...", displayTime:5);
                    shownInGameMsg = true;
                }
                else return;
            }
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


        public static List<WeaponModel> changedWeaponModels = new List<WeaponModel>();
        internal static void UpdateWeapon(Weapon __instance)
        {
            var settings = Settings.settings;

            if (settings.DivideAttackSpeedBy < 0)
                settings.DivideAttackSpeedBy = 0;


            if (!changedWeaponModels.Contains(__instance.weaponModel))
            {
                __instance.weaponModel.rate = __instance.weaponModel.rate / settings.DivideAttackSpeedBy;
                changedWeaponModels.Add(__instance.weaponModel);
            }


            if (settings.EnableInfiniteRange)
            {
                __instance.attack.attackModel.range = 1000;
                __instance.attack.attackModel.attackThroughWalls = true;
            }
        }
    }
}
