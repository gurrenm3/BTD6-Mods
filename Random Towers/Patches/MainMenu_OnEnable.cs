using Assets.Scripts.Unity;
using Assets.Scripts.Unity.UI_New.Main;
using Harmony;
using MelonLoader;

namespace Random_Towers.Patches
{
    [HarmonyPatch(typeof(MainMenu), nameof(MainMenu.OnEnable))]
    internal class MainMenu_OnEnable
    {
        static bool skipFirst = true;
        [HarmonyPostfix]
        internal static void Postfix()
        {
            if (skipFirst)
            {
                skipFirst = false;
                return;
            }

            TowerRandomizer t = new TowerRandomizer();

            var loadSettings = Settings.LoadedSettings;
            loadSettings.Save();

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