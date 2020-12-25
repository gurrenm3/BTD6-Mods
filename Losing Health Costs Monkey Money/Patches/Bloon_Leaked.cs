using Assets.Scripts.Simulation.Bloons;
using Assets.Scripts.Unity;
using Assets.Scripts.Unity.UI_New.InGame;
using Gurren_Core.Extensions;
using Harmony;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Losing_Health_Costs_Monkey_Money.Patches
{
    [HarmonyPatch(typeof(Bloon), "Leaked")]
    public class Bloon_Leaked
    {
        private static Bloon_Leaked instance = new Bloon_Leaked();

        [HarmonyPrefix]
        internal static bool Prefix(Bloon __instance)
        {
            if (!instance.CanUseMod())
                return true;

            float damage = __instance.GetModifiedTotalLeakDamage();
            var currentMonkeyMoney = Game.instance.GetMonkeyMoney();
            var newMonkeyMoney = instance.GetMonkeyMoneyLoss(damage, currentMonkeyMoney);

            instance.SetMonkeyMoney(newMonkeyMoney);
            instance.UpdateHealth(damage);
            instance.CheckForGameOver();

            return true;
        }


        private bool CanUseMod()
        {
            return !InGame.Bridge.IsSandboxMode();
        }

        private double GetMonkeyMoneyLoss(float damage, double currentMm)
        {
            var settings = Settings.LoadedSettings;

            const double minLossMultiplier = 1;
            if (settings.lossMultiplier < minLossMultiplier)
                settings.lossMultiplier = minLossMultiplier;

            const double noMoney = 0;
            var newMm = currentMm - (damage * settings.lossMultiplier);
            if (newMm < noMoney)
                newMm = noMoney;

            return newMm;
        }

        private void UpdateHealth(float amountToAdd)
        {
            InGame.instance.AddHealth(amountToAdd);
        }

        private void SetMonkeyMoney(double amount)
        {
            Game.instance.SetMonkeyMoney(amount);
        }

        private void CheckForGameOver()
        {
            const double noMoney = 0;
            if (Game.instance.GetMonkeyMoney() <= noMoney)
                InGame.Bridge.Lose();
        }
    }
}