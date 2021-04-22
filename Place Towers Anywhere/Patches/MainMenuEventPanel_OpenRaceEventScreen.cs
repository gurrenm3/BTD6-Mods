using Assets.Scripts.Unity.UI_New.Main.EventPanel;
using Harmony;

namespace Place_Towers_Anywhere.Patches
{
    [HarmonyPatch(typeof(MainMenuEventPanel), nameof(MainMenuEventPanel.OpenRaceEventScreen))]
    internal class MainMenuEventPanel_OpenRaceEventScreen
    {
        [HarmonyPostfix]
        internal static void Postfix()
        {
            SessionData.CurrentSession.RaceChecker.IsInRace = true;

            foreach (var towerData in SessionData.CurrentSession.AllTowerData)
            {
                towerData.UnModTowerModel(towerData.TowerModel);
            }
        }
    }
}