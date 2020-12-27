using Harmony;
using Assets.Scripts.Unity.UI_New.InGame;
using Assets.Scripts.Unity;
using Gurren_Core.Extensions;

namespace Random_Hero.Patches
{
    [HarmonyPatch(typeof(InGame), nameof(InGame.StartMatch))]
    internal class InGame_StartMatch
    {
        [HarmonyPostfix]
        internal static void Postfix()
        {
            
        }
    }
}
