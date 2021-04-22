using Assets.Scripts.Unity.UI_New.Main;
using Harmony;

namespace Random_Tower_Speed_and_Range.Patches
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