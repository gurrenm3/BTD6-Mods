using Assets.Scripts.Unity.UI_New.Main;
using Harmony;
using System;

namespace Free_Powers.Patches
{
    [HarmonyLib.HarmonyPatch(typeof(MainMenu), "Open")]
    internal class MainMenu_OnEnable
    {
        [HarmonyLib.HarmonyPostfix]
        internal static void Postfix()
        {
            if (SessionData.CurrentSession.IsCheating)
            {
                SessionData.CurrentSession.ResetCheatStatus();
            }

            SessionData.CurrentSession.PowersManager.SetAllPowersFree();
        }
    }
}
