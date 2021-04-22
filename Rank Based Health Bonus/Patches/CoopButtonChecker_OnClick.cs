using Assets.Scripts.Unity.UI_New.Coop;
using Harmony;

namespace Rank_Based_Health_Bonus.Patches
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
