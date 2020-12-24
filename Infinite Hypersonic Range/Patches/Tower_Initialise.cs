using Assets.Scripts.Simulation.Towers;
using Harmony;

namespace Infinite_Hypersonic_Range.Patches
{
    [HarmonyPatch(typeof(Tower), "Initialise")]
    public class Tower_Initialise
    {
        [HarmonyPostfix]
        public static void Postfix(Tower __instance)
        {
            if (SessionData.CurrentSession.IsCheating)
                return;

            if (Settings.LoadedSettings.EnableInfiniteRange)
            {
                __instance.towerModel.range = 999999;
                __instance.towerModel.isGlobalRange = true;
            }
        }
    }
}