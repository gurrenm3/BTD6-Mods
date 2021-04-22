using Assets.Scripts.Unity.UI_New.Main;
using Harmony;

namespace Aim_All_Towers.Patches
{
    [HarmonyPatch(typeof(MainMenu), nameof(MainMenu.OnEnable))]
    internal class MainMenu_OnEnable
    {
        private static bool skipFirst = true;
        
        [HarmonyPostfix]
        internal static void Postfix()
        {
            // skip first because MainMenu.OnEnable gets called twice when you first start the game
            if (skipFirst)
            {
                skipFirst = false;
                return;
            }

            if (!SessionData.CurrentSession.TowersModded)
            {
                SessionData.CurrentSession.TowerModifier.ModAllTowers();
                SessionData.CurrentSession.TowersModded = true;
            }
        }
    }
}