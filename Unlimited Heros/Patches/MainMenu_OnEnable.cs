using Assets.Scripts.Unity.UI_New.Main;
using Harmony;

namespace Unlimited_Heros.Patches
{
    [HarmonyPatch(typeof(MainMenu), nameof(MainMenu.OnEnable))]
    internal class MainMenu_OnEnable
    {
        [HarmonyPostfix]
        internal static void Postfix()
        {
            if (SessionData.CurrentSession.IsCheating)
            {
                SessionData.CurrentSession.ResetCheatStatus();
            }            
        }
    }
}