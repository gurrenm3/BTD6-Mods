using Assets.Scripts.Unity.UI_New.Main.EventPanel;
using Harmony;

namespace Rank_Based_Cash_Bonuses.Patches
{
    [HarmonyPatch(typeof(MainMenuEventPanel), nameof(MainMenuEventPanel.OpenRaceEventScreen))]
    internal class MainMenuEventPanel_OpenRaceEventScreen
    {
        [HarmonyPostfix]
        internal static void Postfix()
        {
            SessionData.CurrentSession.RaceChecker.IsInRace = true;
        }
    }
}