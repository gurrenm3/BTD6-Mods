using Assets.Scripts.Simulation;
using Assets.Scripts.Unity.UI_New.InGame;
using Gurren_Core.Logging;
using Harmony;


namespace Buying_Towers_Costs_Monkey_Money.Patches
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

            string text = "Notice! You're using a mod that makes towers cost Monkey Money. Proceed with caution...";
            Logger.ShowMessage(text, "Towers Cost MM", displayTime: 9);
            SessionData.CurrentSession.shownWarningMessage = true;
        }
    }
}
