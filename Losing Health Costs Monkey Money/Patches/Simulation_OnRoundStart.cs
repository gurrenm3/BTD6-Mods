using Assets.Scripts.Simulation;
using Assets.Scripts.Unity.UI_New.InGame;
using Gurren_Core.Logging;
using Harmony;

namespace Losing_Health_Costs_Monkey_Money.Patches
{
    [HarmonyPatch(typeof(Simulation), "OnRoundStart")]
    public class Simulation_OnRoundStart
    {
        [HarmonyPostfix]
        internal static void Postfix()
        {
            bool isCheating = SessionData.CurrentSession.IsCheating;
            bool shownWarning = SessionData.CurrentSession.shownWarningMessage;
            bool isSandbox = InGame.instance.IsSandbox;
            if (isCheating || shownWarning || isSandbox)
                return;

            string text = "Notice! You are playing a gamemode that causes you to lose Monkey Money when you lose health." +
                " Proceed with caution...";

            Logger.ShowMessage(text, "Losing Health Costs MM", displayTime: 9);
            SessionData.CurrentSession.shownWarningMessage = true;
        }
    }
}
