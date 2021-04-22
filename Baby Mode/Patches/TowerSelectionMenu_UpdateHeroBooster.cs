using Assets.Scripts.Unity.Bridge;
using Assets.Scripts.Unity.UI_New.InGame.TowerSelectionMenu;
using Harmony;

namespace Baby_Mode.Patches
{
    [HarmonyPatch(typeof(TowerSelectionMenu), "UpdateHeroBooster")]
    public class TowerSelectionMenu_UpdateHeroBooster
    {
        [HarmonyPostfix]
        public static void Postfix(TowerToSimulation tower)
        {
            if (SessionData.CurrentSession.IsCheating)
                return;


            if (!Settings.LoadedSettings.ApplyToHeros)
                return;

            if (tower.hero != null)
                tower.hero.hero.heroModel.costPerXpToLevel /= 2;
        }
    }
}