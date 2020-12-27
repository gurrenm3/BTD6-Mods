using Harmony;
using Assets.Scripts.Unity.UI_New.InGame;
using Assets.Scripts.Unity;
using Gurren_Core.Extensions;
using Random_Hero.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Random_Hero.Patches
{
    [HarmonyPatch(typeof(InGame), nameof(InGame.StartMatch))]
    internal class InGame_StartMatch
    {
        [HarmonyPostfix]
        internal static void Postfix(InGame __instance)
        {
            var profile = Game.instance.GetProfileModel();
            List<string> unlockedHeros = new List<string>();

            foreach (var hero in profile.unlockedHeroes)
            {
                if (!unlockedHeros.Contains(hero))
                    unlockedHeros.Add(hero);
            }

            Random rand = new Random();
            var randomHeroIndex = rand.Next(unlockedHeros.Count);

            for (int i = 0; i < unlockedHeros.Count; i++)
            {
                var towerModel = Game.instance.model.towers.FirstOrDefault(a => a.name == unlockedHeros[i]);
                if (towerModel is null)
                    continue;

                var detailModel = towerModel.GetTowerDetailsModel();
                if (detailModel is null)
                    continue;

                detailModel.towerCount = (i == randomHeroIndex) ? 1 : 0;
            }

            var towerInventory = TowerInventory_Init.towerInventory;
            towerInventory.SetTowerMaxes(TowerInventory_Init.allTowers);
        }
    }
}
