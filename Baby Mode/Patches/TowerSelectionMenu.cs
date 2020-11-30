using Assets.Scripts.Unity.Bridge;
using Assets.Scripts.Unity.UI_New.InGame.TowerSelectionMenu;
using Harmony;

namespace Baby_Mode.Patches
{
    [HarmonyPatch(typeof(TowerSelectionMenu), "UpdateHeroBooster")]
    public class HeroUpgradeDetails_Patch
    {
        [HarmonyPostfix]
        public static void Postfix(TowerToSimulation tower)
        {
            if (MelonMain.isInRace)
                return;


            if (!Settings.settings.ApplyToHeros)
                return;

            if (tower.hero != null)
                tower.hero.hero.heroModel.costPerXpToLevel /= 2;
        }
    }
}
