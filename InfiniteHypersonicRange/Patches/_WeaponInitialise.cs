using Assets.Scripts.Simulation.Towers.Weapons;
using Harmony;

namespace InfiniteHypersonicRange.Patches
{
    [HarmonyPatch(typeof(Weapon), "Initialise")]
    internal class Weapon_Initialise_Patch
    {
        [HarmonyPostfix]
        internal static void Postfix(Weapon __instance)
        {
            if (MelonMain.isInRace)
                return;

            MelonMain.UpdateWeapon(__instance);
        }
    }
}
