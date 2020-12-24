using Assets.Scripts.Simulation.Towers.Projectiles.Behaviors;
using Harmony;

namespace Infinite_Hypersonic_Range.Patches
{
    [HarmonyPatch(typeof(TravelStrait), "Initialise")]

    internal class TravelStrait_Initialise
    {
        [HarmonyPostfix]
        internal static void Postfix(ref TravelStrait __instance)
        {
            if (SessionData.CurrentSession.IsCheating)
                return;

            if (Settings.LoadedSettings.EnableInfiniteRange)
            {
                __instance.travelStraitModel.lifespan = 150;
                __instance.travelStraitModel.lifespanFrames = 150;
            }
        }
    }
}