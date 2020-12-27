using Assets.Scripts.Models;
using Assets.Scripts.Models.Towers;
using Assets.Scripts.Simulation.Towers;
using Assets.Scripts.Unity;
using Harmony;
using MelonLoader;
using System;

namespace Random_Towers.Patches
{
    [HarmonyPatch(typeof(Tower), nameof(Tower.Initialise))]
    internal class Tower_Initialise
    {
        internal static Random rand = new Random();

        [HarmonyPrefix]
        internal static bool Prefix(ref Tower __instance, ref Model modelToUse)
        {
            if (SessionData.CurrentSession.IsCheating)
                return true;

            var settings = Settings.LoadedSettings;
            /*if (!settings.AllowedTowers.Contains(__instance.towerModel.name))
                return;*/

            TowerModel newTower = null;
            for (int i = 0; i < 10; i++)
            {
                newTower = GetNewTower();
                if (newTower != null)
                    break;
            }

            if (newTower != null)
                modelToUse = newTower;

            return true;
        }

        internal static int GetUpgrade(int min, int max) => rand.Next(min, max + 1);

        internal static TowerModel GetNewTower()
        {
            var settings = Settings.LoadedSettings;
            string newTowerName = settings.AllowedTowers[rand.Next(0, settings.AllowedTowers.Count)];

            if (!settings.AllowRandomUpgrades)
                return Game.instance.model.GetTower(newTowerName);

            int tier1 = 0;
            int tier2 = 0;
            int tier3 = 0;

            int firstUpgradePath = rand.Next(1, 3);
            switch (firstUpgradePath)
            {
                case 1:
                    tier1 = GetUpgrade(0, settings.MaxRandomUpgrade);
                    break;
                case 2:
                    tier2 = GetUpgrade(0, settings.MaxRandomUpgrade);
                    break;
                case 3:
                    tier3 = GetUpgrade(0, settings.MaxRandomUpgrade);
                    break;
            }

            int nextUpgradePath = rand.Next(1, 3);
            while (nextUpgradePath == firstUpgradePath)
                nextUpgradePath = rand.Next(1, 3);


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

            return Game.instance.model.GetTower(newTowerName, tier1, tier2, tier3);
        }
    }
}