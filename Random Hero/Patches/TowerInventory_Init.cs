using Assets.Scripts.Models.TowerSets;
using Assets.Scripts.Simulation.Input;
using Harmony;
using Il2CppSystem.Collections.Generic;

namespace Random_Hero.Patches
{
    [HarmonyPatch(typeof(TowerInventory), nameof(TowerInventory.Init))]
    internal class TowerInventory_Init
    {
        public static List<TowerDetailsModel> allTowers = new List<TowerDetailsModel>();
        public static TowerInventory towerInventory;

        [HarmonyPrefix]
        internal static bool Prefix(TowerInventory __instance, ref List<TowerDetailsModel> allTowersInTheGame)
        {
            towerInventory = __instance;
            allTowers = allTowersInTheGame;
            return true;
        }
    }
}