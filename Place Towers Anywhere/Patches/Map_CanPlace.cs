using Assets.Scripts.Models.Map;
using Assets.Scripts.Simulation.Track;
using Harmony;

namespace Place_Towers_Anywhere.Patches
{
    [HarmonyPatch(typeof(Map), nameof(Map.CanPlace))]
    internal class Map_CanPlace
    {
        [HarmonyPostfix]
        internal static void Patch(ref bool __result)
        {
            if (!SessionData.CurrentSession.IsCheating)
                __result = true;
        }
    }
}