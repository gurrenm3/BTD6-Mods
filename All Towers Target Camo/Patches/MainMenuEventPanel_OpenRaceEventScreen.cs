using Assets.Scripts.Unity.UI_New.Main.EventPanel;
using Harmony;

namespace All_Towers_Target_Camo.Patches
{
    [HarmonyPatch(typeof(MainMenuEventPanel), nameof(MainMenuEventPanel.OpenRaceEventScreen))]
    internal class MainMenuEventPanel_OpenRaceEventScreen
    {
        [HarmonyPostfix]
        internal static void Postfix()
        {
            SessionData.CurrentSession.RaceChecker.IsInRace = true;
            SessionData.CurrentSession.BloonModifier.ResetCamoToDefault();
        }
    }
}