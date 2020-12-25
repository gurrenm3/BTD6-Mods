using Assets.Scripts.Models.Map;
using Assets.Scripts.Models.Towers;
using Assets.Scripts.Unity;
using Assets.Scripts.Unity.UI_New.Main;
using Harmony;
using System.Linq;
using UnhollowerBaseLib;

namespace Place_Towers_Anywhere.Patches
{
    [HarmonyPatch(typeof(MainMenu), nameof(MainMenu.OnEnable))]
    internal class MainMenu_OnEnable
    {
        static bool finishedSetup = false;

        [HarmonyPostfix]
        internal static void Postfix()
        {
            if (!finishedSetup)
                Setup();

            if (SessionData.CurrentSession.IsCheating)
            {
                SessionData.CurrentSession.ResetCheatStatus();
            }

            foreach (var towerData in SessionData.CurrentSession.AllTowerData)
            {
                towerData.ModTowerModel(towerData.TowerModel);
            }
        }

        private static void Setup()
        {
            var allTowerModels = Game.instance.model.towers;
            for (int i = 0; i < allTowerModels.Count; i++)
            {
                var towerModel = allTowerModels[i];
                AddToDataList(towerModel);
            }

            finishedSetup = true;
        }

        private static void AddToDataList(TowerModel towerModel)
        {
            var result = SessionData.CurrentSession.AllTowerData.FirstOrDefault(data => data.TowerModel == towerModel);
            if (result != null)
                return;

            var towerData = new TowerData()
            {
                TowerModel = towerModel,
                Radius = towerModel.radius,
                RadiusSquared = towerModel.radiusSquared
            };

            var areaCount = towerModel.areaTypes.Count;
            towerData.AreaTypes = new Il2CppStructArray<AreaType>(areaCount);
            for (int i = 0; i < towerModel.areaTypes.Count; i++)
            {
                var areaType = towerModel.areaTypes[i];
                towerData.AreaTypes[i] = areaType;
            }

            SessionData.CurrentSession.AllTowerData.Add(towerData);
        }
    }
}