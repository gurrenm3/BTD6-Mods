using Harmony;
using Heros_Only.Extensions;
using Assets.Scripts.Unity.UI_New.InGame;
using Assets.Scripts.Unity;
using System.Linq;
using MelonLoader;

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
                var test = Settings.LoadedSettings.allowedTowers.FirstOrDefault(t => tower.towerId == t);
                bool isValidTowerModel = Game.instance.model.GetTower(test) != null;

                if (!tower.IsHero() && !isValidTowerModel)
                    continue;

                tower.towerCount = -1;
            }

            towerInventory.SetTowerMaxes(allTowers);
        }
    }
}
