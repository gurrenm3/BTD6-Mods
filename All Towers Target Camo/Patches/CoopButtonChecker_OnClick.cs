using Assets.Scripts.Unity.UI_New.Coop;
using Harmony;

namespace All_Towers_Target_Camo.Patches
{
    [HarmonyPatch(typeof(CoopQuickMatchScreen), nameof(CoopQuickMatchScreen.Open))]
    internal class CoopButtonChecker_OnClick
    {
        [HarmonyPostfix]
        internal static void Postfix()
        {
            SessionData.CurrentSession.CoopChecker.IsInPublicCoop = true;
            SessionData.CurrentSession.BloonModifier.ResetCamoToDefault();
        }
    }
}
