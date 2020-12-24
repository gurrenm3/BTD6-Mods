using Assets.Scripts.Simulation.Towers;
using Harmony;

namespace Infinite_Hypersonic_Range.Patches
{
    [HarmonyPatch(typeof(Tower), "UpdatedModel")]
    public class Tower_UpdatedModel
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