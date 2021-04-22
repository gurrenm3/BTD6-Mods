using Assets.Scripts.Simulation.Input;
using Harmony;

namespace Infinite_5th_Tiers.Patches
{
    [HarmonyPatch(typeof(TowerInventory), nameof(TowerInventory.IsPathTierLocked))]
    internal class TowerInventory_IsPathTierLocked
    {
        [HarmonyPostfix]
        internal static void Postfix(ref bool __result)
        {
            if (!SessionData.CurrentSession.IsCheating)
                __result = false;
        }
    }
}