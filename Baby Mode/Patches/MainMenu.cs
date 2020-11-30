using Assets.Scripts.Unity.UI_New.Main;
using Harmony;

namespace Baby_Mode.Patches
{
    [HarmonyPatch(typeof(MainMenu), "OnEnable")]
    internal class MainMenuOnEnable_Patch
    {
        [HarmonyPostfix]
        internal static void Postfix()
        {
            if (Settings.settings == null)
                Settings.LoadSettings();

            MelonMain.isInRace = false;
            MelonMain.shownInGameMsg = true;
        }
    }
}
