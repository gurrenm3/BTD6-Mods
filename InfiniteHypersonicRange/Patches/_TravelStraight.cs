using Assets.Scripts.Simulation.Towers.Projectiles.Behaviors;
using Harmony;

namespace InfiniteHypersonicRange.Patches
{
    [HarmonyPatch(typeof(TravelStrait), "Initialise")]

    internal class TravelStrait_Initialise_Patch
    {
        [HarmonyPostfix]
        internal static void Postfix(ref TravelStrait __instance)
        {
            if (MelonMain.isInRace)
                return;

            if (Settings.settings.EnableInfiniteRange)
            {
                __instance.travelStraitModel.lifespan = 150;
                __instance.travelStraitModel.lifespanFrames = 150;
            }
        }
    }
}
