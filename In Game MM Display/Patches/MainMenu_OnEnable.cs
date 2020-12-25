using Assets.Scripts.Unity.UI_New.Main;
using Harmony;

namespace In_Game_MM_Display.Patches
{
    [HarmonyPatch(typeof(MainMenu), nameof(MainMenu.OnEnable))]
    internal class MainMenu_OnEnable
    {
        [HarmonyPostfix]
        internal static void Postfix()
        {
            var loadSettings = Settings.LoadedSettings;
        }
    }
}