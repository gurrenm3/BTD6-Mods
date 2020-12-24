using Assets.Scripts.Models.Towers.Weapons;
using Assets.Scripts.Simulation.Towers.Weapons;
using System.Collections.Generic;
using System.Linq;

namespace Infinite_Hypersonic_Range
{
    class WeaponHandler
    {
        public static List<WeaponModel> changedWeaponModels = new List<WeaponModel>();
        internal static void UpdateWeapon(Weapon __instance)
        {
            var settings = Settings.LoadedSettings;

            if (settings.DivideAttackSpeedBy < 0)
                settings.DivideAttackSpeedBy = 0;


            if (!changedWeaponModels.Contains(__instance.weaponModel))
            {
                __instance.weaponModel.rate = __instance.weaponModel.rate / settings.DivideAttackSpeedBy;
                changedWeaponModels.Add(__instance.weaponModel);
            }


            if (settings.EnableInfiniteRange)
            {
                __instance.attack.attackModel.range = 1000;
                __instance.attack.attackModel.attackThroughWalls = true;
            }
        }
    }
}