using Assets.Scripts.Models.TowerSets;
using Assets.Scripts.Simulation.Input;
using Assets.Scripts.Unity.UI_New.InGame;
using Random_Hero.Patches;
using Il2CppSystem.Collections.Generic;

namespace Random_Hero.Extensions
{
    public static class InGameExt
    {
        public static TowerInventory GetTowerInventory(this InGame inGame) => TowerInventory_Init.towerInventory;
        public static List<TowerDetailsModel> GetAllTowerDetailModels(this InGame inGame) => TowerInventory_Init.allTowers;
    }
}
