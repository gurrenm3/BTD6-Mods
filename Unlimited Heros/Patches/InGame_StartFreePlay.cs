using Assets.Scripts.Unity.UI_New.InGame;
using Harmony;
using Unlimited_Heros.Extensions;

namespace Unlimited_Heros.Patches
{
    [HarmonyPatch(typeof(InGame), nameof(InGame.StartFreePlay))]
    internal class InGame_StartFreePlay
    {
        [HarmonyPostfix]
        internal static void prefix()
        {
            var towerInventory = TowerInventory_Init.towerInventory;
            var allTowers = TowerInventory_Init.allTowers;
            foreach (var tower in allTowers)
            {
                if (!tower.IsHero())
                    continue;

                tower.towerCount = -1;
            }

            towerInventory.SetTowerMaxes(allTowers);
        }
    }
}