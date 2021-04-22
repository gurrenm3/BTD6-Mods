using Assets.Scripts.Unity.UI_New.Odyssey;
using Harmony;

namespace Place_Towers_Anywhere.Patches
{
    [HarmonyPatch(typeof(OdysseyEventScreen), nameof(OdysseyEventScreen.Update))]
    internal class OdysseyEventScreen_Update
    {
        [HarmonyPostfix]
        internal static void Postfix()
        {
            SessionData.CurrentSession.OdysseyChecker.IsInOdyssey = true;

            foreach (var towerData in SessionData.CurrentSession.AllTowerData)
            {
                towerData.UnModTowerModel(towerData.TowerModel);
            }
        }
    }
}
