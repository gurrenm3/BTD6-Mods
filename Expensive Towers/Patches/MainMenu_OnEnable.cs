using Assets.Scripts.Unity;
using Assets.Scripts.Unity.UI_New.Main;
using Harmony;

namespace Expensive_Towers.Patches
{
    [HarmonyPatch(typeof(MainMenu), nameof(MainMenu.OnEnable))]
    internal class MainMenu_OnEnable
    {
        [HarmonyPostfix]
        internal static void Postfix()
        {
            var settings = Settings.LoadedSettings;

            if (SessionData.setPrices)
                return;

            if (settings.CostMultiplier < 1)
                settings.CostMultiplier = 1;

            foreach (var item in Game.instance.model.towers)
                item.cost *= settings.CostMultiplier;

            foreach (var upgrade in Game.instance.model.upgrades)
                upgrade.cost *= (int)settings.CostMultiplier;

            SessionData.setPrices = true;
        }
    }
}