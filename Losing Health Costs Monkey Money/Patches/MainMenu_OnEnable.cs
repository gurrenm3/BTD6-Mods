using Assets.Scripts.Unity.UI_New.Main;
using Harmony;

namespace Losing_Health_Costs_Monkey_Money.Patches
{
    [HarmonyPatch(typeof(MainMenu), nameof(MainMenu.OnEnable))]
    internal class MainMenu_OnEnable
    {
        [HarmonyPostfix]
        internal static void Postfix()
        {
            var loadSettings = Settings.LoadedSettings;
            SessionData.CurrentSession.shownWarningMessage = false;

            if (SessionData.CurrentSession.IsCheating)
            {
                SessionData.CurrentSession.ResetCheatStatus();
            }
        }
    }
}