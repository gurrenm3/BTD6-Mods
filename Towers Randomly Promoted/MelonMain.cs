using Assets.Scripts.Unity;
using Assets.Scripts.Unity.UI_New.InGame;
using MelonLoader;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Towers_Randomly_Promoted.Extensions;

namespace Towers_Randomly_Promoted
{
    public class MelonMain : MelonMod
    {
        internal static string modDir = $"{Environment.CurrentDirectory}\\Mods\\{Assembly.GetExecutingAssembly().GetName().Name}";

        public override void OnApplicationStart()
        {
            string modName = Assembly.GetExecutingAssembly().GetName().Name;
            MelonLogger.Log($"{modName} will not work in Races, Odyssey, and Public Co-op matches. This is for your own" +
                $" protection so you're account doesn't get in trouble.");

            MelonLogger.Log($"You can change the settings for {modName} by going to the settings folder. It's located at" +
                $" \"BloonsTD6\\Mods\\{modName}\\settings.json\"");

            MelonLogger.Log("Mod has finished loading");
        }

        public override void OnUpdate()
        {
            if (InGame.instance?.bridge is null)
                return;

            if (InGame.instance.IsSandbox && !Settings.LoadedSettings.WorkInSandbox)
                return;

            if (!InGame.instance.bridge.AreRoundsActive())
                return;

            if (SessionData.CurrentSession.PromotionManager is null)
                SessionData.CurrentSession.PromotionManager = new TowerPromotionManager();

            if (SessionData.CurrentSession.PromotionManager.CanPromoteTower())
                SessionData.CurrentSession.PromotionManager.PromoteRandomTower();
        }
    }
}