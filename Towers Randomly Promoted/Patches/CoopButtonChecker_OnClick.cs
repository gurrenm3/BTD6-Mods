using Assets.Scripts.Unity.UI_New.Coop;
using Harmony;

namespace Towers_Randomly_Promoted.Patches
{
    [HarmonyPatch(typeof(CoopQuickMatchScreen), nameof(CoopQuickMatchScreen.Open))]
    internal class CoopButtonChecker_OnClick
    {
        [HarmonyPostfix]
        internal static void Postfix()
        {
            SessionData.CurrentSession.CoopChecker.IsInPublicCoop = true;
        }
    }
}
