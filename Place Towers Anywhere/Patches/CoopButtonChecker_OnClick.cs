using Assets.Scripts.Unity.UI_New.Coop;
using Harmony;

namespace Place_Towers_Anywhere.Patches
{
    [HarmonyPatch(typeof(CoopQuickMatchScreen), nameof(CoopQuickMatchScreen.Open))]
    internal class CoopButtonChecker_OnClick
    {
        [HarmonyPostfix]
        internal static void Postfix()
        {
            SessionData.CurrentSession.CoopChecker.IsInPublicCoop = true;

            foreach (var towerData in SessionData.CurrentSession.AllTowerData)
            {
                towerData.UnModTowerModel(towerData.TowerModel);
            }
        }
    }
}
