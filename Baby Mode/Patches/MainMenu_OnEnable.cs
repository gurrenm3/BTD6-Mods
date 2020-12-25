using Assets.Scripts.Unity.UI_New.Main;
using Harmony;

namespace Baby_Mode.Patches
{
    [HarmonyPatch(typeof(MainMenu), nameof(MainMenu.OnEnable))]
    internal class MainMenu_OnEnable
    {
        [HarmonyPostfix]
        internal static void Postfix()
        {
            var loadSettings = Settings.Load();
            if (SessionData.CurrentSession.IsCheating)
            {
                SessionData.CurrentSession.ResetCheatStatus();
            }
        }
    }
}