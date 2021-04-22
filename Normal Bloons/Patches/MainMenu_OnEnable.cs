using Assets.Scripts.Unity.UI_New.Main;
using Harmony;

namespace Normal_Bloons.Patches
{
    [HarmonyPatch(typeof(MainMenu), nameof(MainMenu.OnEnable))]
    internal class MainMenu_OnEnable
    {
        [HarmonyPostfix]
        internal static void Postfix()
        {
            var loadSettings = Settings.LoadedSettings;
            if (SessionData.CurrentSession.IsCheating)
            {
                SessionData.CurrentSession.ResetCheatStatus();
            }
        }
    }
}