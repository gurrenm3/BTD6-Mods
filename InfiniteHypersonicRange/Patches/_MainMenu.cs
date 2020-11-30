using Assets.Scripts.Unity.UI_New.Main;
using Harmony;

namespace InfiniteHypersonicRange.Patches
{
    [HarmonyPatch(typeof(MainMenu), "OnEnable")]
    internal class MainMenu_OnEnable_Patch
    {
        [HarmonyPostfix]
        internal static void Postfix()
        {
            MelonMain.isInRace = false;
            MelonMain.shownInGameMsg = true;
            
            if (Settings.settings == null)
                Settings.LoadSettings();
        }
    }
}
