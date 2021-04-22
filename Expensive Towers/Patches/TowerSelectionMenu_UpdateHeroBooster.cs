using Assets.Scripts.Unity.Bridge;
using Assets.Scripts.Unity.UI_New.InGame.TowerSelectionMenu;
using Harmony;

namespace Expensive_Towers.Patches
{
    [HarmonyPatch(typeof(TowerSelectionMenu), "UpdateHeroBooster")]
    public class TowerSelectionMenu_UpdateHeroBooster
    {
        [HarmonyPostfix]
        public static void Prefix(TowerToSimulation tower)
        {
            var settings = Settings.LoadedSettings;

            if (!settings.ApplyToHeros)
                return;

            if (settings.CostMultiplier < 1)
                settings.CostMultiplier = 1;

            if (tower.hero != null)
                tower.hero.hero.heroModel.costPerXpToLevel *= settings.CostMultiplier;

            return;
        }
    }
}