using Assets.Scripts.Unity.UI_New.Main;
using Harmony;

namespace All_Towers_Target_Camo.Patches
{
    [HarmonyPatch(typeof(MainMenu), nameof(MainMenu.OnEnable))]
    internal class MainMenu_OnEnable
    {
        public static BloonModifier bloonModifier;

        [HarmonyPostfix]
        internal static void Postfix()
        {
            if (SessionData.CurrentSession.IsCheating)
            {
                SessionData.CurrentSession.ResetCheatStatus();
            }


            if (SessionData.CurrentSession.BloonModifier is null)
                SessionData.CurrentSession.BloonModifier = new BloonModifier();

            SessionData.CurrentSession.BloonModifier.RemoveCamoAll();
        }
    }
}