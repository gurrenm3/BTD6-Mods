namespace Harder_Bloons.Patches.MainMenu
{
    using Harmony;
    using Assets.Scripts.Unity.UI_New.Main;

    [HarmonyPatch(typeof(MainMenu), "OnEnable")]
    public class MainMenu_OnEnable_Patch
    {
        [HarmonyPostfix]
        public static void Postfix()
        {
            if (Settings.settings == null)
                Settings.LoadSettings();
        }
    }
}
