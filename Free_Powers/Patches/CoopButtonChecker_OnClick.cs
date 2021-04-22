using Harmony;
using Assets.Scripts.Unity.UI_New.Coop;

namespace Free_Powers.Patches
{
    [HarmonyPatch(typeof(CoopQuickMatchScreen), nameof(CoopQuickMatchScreen.Open))]
    internal class CoopButtonChecker_OnClick
    {
        [HarmonyPostfix]
        internal static void Postfix()
        {
            SessionData.CurrentSession.CoopChecker.IsInPublicCoop = true;
            SessionData.CurrentSession.PowersManager.ResetAllPowerCosts();
        }
    }
}