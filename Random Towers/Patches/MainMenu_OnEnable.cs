using Assets.Scripts.Unity.UI_New.Main;
using Harmony;

namespace Random_Towers.Patches
{
    [HarmonyPatch(typeof(MainMenu), nameof(MainMenu.OnEnable))]
    internal class MainMenu_OnEnable
    {
        [HarmonyPostfix]
        internal static void Postfix()
        {
            var loadSettings = Settings.LoadedSettings;
            if (loadSettings.AllowedTowers.Count == 0)
            {
                loadSettings.AllowedTowers = TowerTypes.defaultAllowTypes;
                Settings.LoadedSettings.Save();
            }

            if (SessionData.CurrentSession.IsCheating)
            {
                SessionData.CurrentSession.ResetCheatStatus();
            }
        }
    }
}