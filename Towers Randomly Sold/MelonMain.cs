using Assets.Scripts.Unity;
using Assets.Scripts.Unity.UI_New.InGame;
using MelonLoader;
using System;
using System.Reflection;
using UnityEngine;

namespace Towers_Randomly_Sold
{
    public class MelonMain : MelonMod
    {
        internal static string modDir = $"{Environment.CurrentDirectory}\\Mods\\{Assembly.GetExecutingAssembly().GetName().Name}";

        public override void OnApplicationStart()
        {
            MelonLogger.Log("Mod has finished loading");
        }

        public override void OnUpdate()
        {
            if (Game.instance is null)
                return;

            if (InGame.instance is null || InGame.instance.bridge is null)
                return;

            if (InGame.instance.IsSandbox && !Settings.LoadedSettings.WorkInSandbox)
                return;

            if (!InGame.instance.bridge.AreRoundsActive())
                return;

            if (SessionData.towerSellManager is null)
                SessionData.towerSellManager = new TowerSellManager();

            if (SessionData.towerSellManager.CanSellTower())
                SessionData.towerSellManager.SellRandomTower();
        }
    }
}