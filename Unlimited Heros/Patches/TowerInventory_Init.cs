using Assets.Scripts.Models.TowerSets;
using Assets.Scripts.Simulation.Input;
using Harmony;
using Il2CppSystem.Collections.Generic;
using Assets.Scripts.Unity;
using Gurren_Core.Extensions;
using MelonLoader;

namespace Unlimited_Heros.Patches
{
    [HarmonyPatch(typeof(TowerInventory), nameof(TowerInventory.Init))]
    internal class TowerInventory_Init
    {
        public static List<TowerDetailsModel> allTowers = new List<TowerDetailsModel>();
        public static TowerInventory towerInventory;

        [HarmonyPostfix]
        internal static void Postfix(TowerInventory __instance, ref List<TowerDetailsModel> allTowersInTheGame)
        {
            towerInventory = __instance;
            allTowers = allTowersInTheGame;

            if (SessionData.CurrentSession.IsCheating)
                return;

            var unlockedHeros = Game.instance.GetProfileModel().unlockedHeroes;
            for (int i = 0; i < allTowersInTheGame.Count; i++)
            {
                var tower = allTowersInTheGame[i];
                var heroDetailsModel = tower.TryCast<HeroDetailsModel>();
                var isHero = heroDetailsModel != null;
                if (!isHero)
                    continue;


                bool hasHero = unlockedHeros.Contains(tower.towerId);
                if (!hasHero)
                    continue;


                allTowersInTheGame[i].towerCount = -1;
            }

            return;
        }
    }
}