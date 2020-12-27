using Harmony;
using Heros_Only.Extensions;
using Assets.Scripts.Unity.UI_New.InGame;

namespace Heros_Only.Patches
{
    [HarmonyPatch(typeof(InGame), nameof(InGame.StartMatch))]
    internal class InGame_StartMatch
    {
        [HarmonyPostfix]
        internal static void Postfix()
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
