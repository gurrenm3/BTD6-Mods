using Assets.Scripts.Simulation;
using Assets.Scripts.Unity.UI_New.InGame;
using Harmony;
using Gurren_Core.Extensions;
using Assets.Scripts.Unity;

namespace Rank_Based_Cash_Bonuses.Patches
{
    [HarmonyPatch(typeof(Simulation), nameof(Simulation.OnRoundEnd))]
    internal class Simulation_OnRoundEnd
    {
        [HarmonyPostfix]
        internal static void Postfix(int round)
        {
            const int roundOffset = 1;
            int roundNumber = round + roundOffset;

            const int bonusRound = 10;
            int multiplier = (roundNumber % bonusRound == 0) ? 300 : 1;

            var playerRank = Game.instance.GetProfileModel().rank.Value;
            var cashToAdd = playerRank * multiplier;
            InGame.instance.AddCash(cashToAdd);
        }
    }
}