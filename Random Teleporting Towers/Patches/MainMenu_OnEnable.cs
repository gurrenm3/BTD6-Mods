using Assets.Scripts.Unity.UI_New.Main;
using Harmony;

namespace Random_Teleporting_Towers.Patches
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

            SessionData.CurrentSession.TimeToNextRandom = 0;
            SessionData.CurrentSession.RoundsSinceLastRandom = 0;
        }
    }
}