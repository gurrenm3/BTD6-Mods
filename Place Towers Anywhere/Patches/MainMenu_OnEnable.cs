using Assets.Scripts.Models.Map;
using Assets.Scripts.Models.Towers;
using Assets.Scripts.Unity;
using Assets.Scripts.Unity.UI_New.Main;
using Harmony;

namespace Place_Towers_Anywhere.Patches
{
    [HarmonyPatch(typeof(MainMenu), nameof(MainMenu.OnEnable))]
    internal class MainMenu_OnEnable
    {
        private static MainMenu_OnEnable patch = new MainMenu_OnEnable();

        [HarmonyPostfix]
        public static void HarmonyPatch()
        {
            patch.ExecutePatch();
        }

        public void ExecutePatch()
        {
            ModAllTowers();
        }

        private void ModAllTowers()
        {
            var allTowerModels = Game.instance.model.towers;
            for (int i = 0; i < allTowerModels.Count; i++)
            {
                var towerModel = allTowerModels[i];
                SetTowerModelRadius(towerModel);
                SetTowerModelAreaTypes(towerModel);
            }
        }

        private void SetTowerModelRadius(TowerModel towerModel)
        {
            towerModel.radius = 0;
            towerModel.radiusSquared = 0;
        }

        private void SetTowerModelAreaTypes(TowerModel towerModel)
        {
            towerModel.areaTypes = new UnhollowerBaseLib.Il2CppStructArray<AreaType>(4);

            var areaTypes = towerModel.areaTypes;
            areaTypes[0] = AreaType.ice;
            areaTypes[1] = AreaType.land;
            areaTypes[2] = AreaType.water;
            areaTypes[2] = AreaType.track;
        }
    }
}