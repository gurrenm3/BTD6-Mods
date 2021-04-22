using Harmony;
using Unlimited_Heros.Extensions;
using Assets.Scripts.Unity.UI_New.InGame;

namespace Unlimited_Heros.Patches
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
