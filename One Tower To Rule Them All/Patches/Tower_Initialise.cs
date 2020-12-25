using System;
using Harmony;
using MelonLoader;
using Assets.Scripts.Models;
using Assets.Scripts.Models.Towers;
using Assets.Scripts.Simulation.Towers;
using Gurren_Core.Api.BTD6;
using Assets.Scripts.Unity;
using Gurren_Core.Extensions;

namespace One_Tower_To_Rule_Them_All.Patches
{
    [HarmonyPatch(typeof(Tower), "Initialise")]
    public class Tower_Initialise
    {
        private static Settings settings;
        private static Random rand = new Random();
        [HarmonyPrefix]
        internal static bool Prefix(ref Tower __instance, ref Model modelToUse)
        {
            if (SessionData.CurrentSession.IsCheating)
                return true;

            settings = Settings.LoadedSettings;

            if (settings.TowerName.Trim() == "" || ((settings.upgrade1 > 0 || settings.upgrade2 > 0 || settings.upgrade3 > 0) &&
                modelToUse.name.ToLower().Contains(settings.TowerName.ToLower())))
                return true;

            int tier1 = settings.upgrade1;
            int tier2 = settings.upgrade2;
            int tier3 = settings.upgrade3;

            TowerModel newModel = null;

            if (settings.UseRandomUpgradesInstead)
                newModel = GetNewTower(settings.TowerName, 5, 5, 5);
            else
                newModel = Game.instance.GetTowerModel(settings.TowerName, tier1, tier2, tier3);

            if (newModel != null)
                modelToUse = newModel;
            else
                MelonLogger.Log("The tower you're trying to set everything to returned null! Make sure you typed everything correctly " +
                    "and didn't try to do anything crazy (5,5,5)");

            return true;
        }

        private static int GetUpgrade(int min, int max)
        {
            int nextUpgrade = 0;

            nextUpgrade = rand.Next(min, max + 1);

            if (nextUpgrade < 0)
                nextUpgrade = 0;

            return nextUpgrade;
        }

        private static TowerModel GetNewTower(string towerName, int tier1Max, int tier2Max, int tier3Max)
        {
            int tier1 = 0;
            int tier2 = 0;
            int tier3 = 0;


            int firstUpgradePath = rand.Next(1, 4);
            switch (firstUpgradePath)
            {
                case 1:
                    tier1 = GetUpgrade(0, tier1Max);
                    break;
                case 2:
                    tier2 = GetUpgrade(0, tier2Max);
                    break;
                case 3:
                    tier3 = GetUpgrade(0, tier3Max);
                    break;
            }

            int nextUpgradePath = rand.Next(1, 4);
            while (nextUpgradePath == firstUpgradePath)
                nextUpgradePath = rand.Next(1, 4);


            switch (nextUpgradePath)
            {
                case 1:
                    tier1 = GetUpgrade(0, 2);
                    break;
                case 2:
                    tier2 = GetUpgrade(0, 2);
                    break;
                case 3:
                    tier3 = GetUpgrade(0, 2);
                    break;
            }

            return Game.instance.GetTowerModel(towerName, tier1, tier2, tier3);
        }
    }
}
