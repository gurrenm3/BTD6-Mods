using Harmony;
using Assets.Scripts.Unity.UI_New.InGame;
using Assets.Scripts.Unity;
using Gurren_Core.Extensions;

namespace Rank_Based_Health_Bonus.Patches
{
    [HarmonyPatch(typeof(InGame), nameof(InGame.StartMatch))]
    internal class InGame_StartMatch
    {
        [HarmonyPostfix]
        internal static void Postfix()
        {
            int currentRound = InGame.instance.bridge.GetCurrentRound();
            bool isNewGame = currentRound == 0;
            if (!isNewGame)
                return;

            var playerRank = Game.instance.GetProfileModel().rank.Value;
            InGame.instance.bridge.simulation.maxHealth.Value += playerRank;
            InGame.instance.bridge.simulation.health.Value += playerRank;
        }
    }
}
