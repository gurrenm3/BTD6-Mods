using Assets.Scripts.Simulation.Bloons;
using Assets.Scripts.Unity.UI_New.InGame;
using Gurren_Core.Extensions;
using Harmony;

namespace Losing_Health_Costs_Money.Patches
{
    [HarmonyPatch(typeof(Bloon), nameof(Bloon.Leaked))]
    public class Bloon_Leaked
    {
        [HarmonyPostfix]
        public static void Postfix(Bloon __instance)
        {
            if (InGame.instance.bridge.IsSandboxMode())
                return;

            var settings = Settings.LoadedSettings;
            const double minLossMultiplier = 1;
            if (settings.lossMultiplier < minLossMultiplier)
                settings.lossMultiplier = minLossMultiplier;

            var cash = InGame.instance.GetCash();
            float damage = __instance.GetModifiedTotalLeakDamage();
            var newCash = cash - (damage * settings.lossMultiplier);

            const double zeroCash = 0;
            if (newCash < zeroCash)
                newCash = zeroCash;

            InGame.instance.SetCash(newCash);
            InGame.instance.AddHealth(damage);

            if (newCash <= zeroCash)
                InGame.instance.bridge.Lose();
        }
    }
}
