namespace One_Tower_to_Rule_Them_All.Patches.MainMenu
{
    using Harmony;
    using One_Tower_To_Rule_Them_All;
    using MainMenu = Assets.Scripts.Unity.UI_New.Main.MainMenu;

    [HarmonyPatch(typeof(MainMenu), "OnEnable")]
    internal class MainMenuOnEnable_Patch
    {
        [HarmonyPostfix]
        internal static void Postfix()
        {
            MelonMain.isInRace = false;

            if (Settings.settings == null)
                Settings.LoadSettings();
        }
    }
}