using Assets.Scripts.Simulation;
using Assets.Scripts.Simulation.Towers;
using Harmony;
using MelonLoader;

namespace Change_Cash_From_Bloon_Pops.Patches
{
    [HarmonyPatch(typeof(Simulation), nameof(Simulation.AddCash))]
    internal class Simulation_AddCash
    {
        [HarmonyPrefix]
        internal static bool Prefix(ref double c, Simulation.CashType from, Simulation.CashSource source, Tower tower)
        {
            bool gainedCash = (c > 0);
            if (!gainedCash)
                return true;

            if (from != Simulation.CashType.Normal || source != Simulation.CashSource.Normal || tower != null)
                return true;

            if (SessionData.CurrentSession.IsCheating)
                return true;

            c = Settings.LoadedSettings.CashPerPop;
            return true;
        }
    }
}