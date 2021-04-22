using Assets.Scripts.Simulation.Towers.Weapons;
using Harmony;

namespace Infinite_Hypersonic_Range.Patches
{
    [HarmonyPatch(typeof(Weapon), "Initialise")]
    internal class Weapon_Initialise
    {
        [HarmonyPostfix]
        internal static void Postfix(Weapon __instance)
        {
            if (SessionData.CurrentSession.IsCheating)
                return;

            WeaponHandler.UpdateWeapon(__instance);
        }
    }
}
