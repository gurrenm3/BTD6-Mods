namespace One_Tower_to_Rule_Them_All.Patches.MainMenuEventPanel
{
    using Harmony;
    using Assets.Scripts.Unity.UI_New.Main.EventPanel;
    using One_Tower_To_Rule_Them_All;

    [HarmonyPatch(typeof(MainMenuEventPanel), "OpenRaceEventScreen")]
    internal class MainMenuEventPanel_OpenRaceEventScreen_Patch
    {
        [HarmonyPostfix]
        internal static void Postfix()
        {
            MelonMain.isInRace = true;
        }
    }
}
