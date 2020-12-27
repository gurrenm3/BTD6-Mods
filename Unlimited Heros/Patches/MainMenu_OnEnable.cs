using Assets.Scripts.Unity.UI_New.Main;
using Harmony;
using Gurren_Core.Extensions;
using Assets.Scripts.Unity;

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

            var player = Game.instance.GetBtd6Player();
            
        }
    }
}