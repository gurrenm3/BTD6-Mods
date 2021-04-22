using Assets.Scripts.Simulation.Towers;
using Assets.Scripts.Unity;
using Assets.Scripts.Unity.UI_New.InGame;
using Gurren_Core.Extensions;
using Harmony;

namespace Buying_Towers_Costs_Monkey_Money.Patches
{
    [HarmonyPatch(typeof(Tower), "Initialise")]
    public class Tower_Initialise
    {
        [HarmonyPostfix]
        public static void Postfix(Tower __instance)
        {
            bool isCheating = SessionData.CurrentSession.IsCheating;
            bool isSandbox = InGame.instance.IsSandbox;

            if (isCheating || isSandbox)
                return;

            float towerCost = __instance.towerModel.cost;
            InGame.instance.AddCash(towerCost);

            var currentMM = Game.instance.GetMonkeyMoney();
            Game.instance.SetMonkeyMoney(currentMM - towerCost);
        }
    }
}