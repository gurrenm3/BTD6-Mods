using Assets.Scripts.Unity.UI_New.Main;
using Harmony;

namespace Random_Hero.Patches
{
    [HarmonyPatch(typeof(MainMenu), nameof(MainMenu.OnEnable))]
    internal class MainMenu_OnEnable
    {
        [HarmonyPostfix]
        internal static void Postfix()
        {

        }
    }
}