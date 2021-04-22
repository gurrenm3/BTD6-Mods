using Assets.Scripts.Unity.UI_New.Odyssey;
using Harmony;

namespace Towers_Randomly_Promoted.Patches
{
    [HarmonyPatch(typeof(OdysseyEventScreen), nameof(OdysseyEventScreen.Update))]
    internal class OdysseyEventScreen_Update
    {
        [HarmonyPostfix]
        internal static void Postfix()
        {
            if (!SessionData.CurrentSession.OdysseyChecker.IsInOdyssey)
            {
                SessionData.CurrentSession.OdysseyChecker.IsInOdyssey = true;
            }
        }
    }
}
