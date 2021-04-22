using Assets.Scripts.Simulation.Towers;
using Harmony;
using BloonsTD6_Mod_Helper.Extensions;
using MelonLoader;
using Assets.Scripts.Unity;
using Assets.Scripts.Simulation.Towers.Weapons.Behaviors;

namespace Ultimate_Ray_of_Doom.Patches
{
    [HarmonyPatch(typeof(Tower), nameof(Tower.Initialise))]
    internal class Tower_Initialse
    {
        [HarmonyPostfix]
        internal static void Postfix(ref Tower __instance)
        {
            if (SessionData.CurrentSession.IsCheating)
                return;

            //__instance.towerModel = Game.instance.model.GetTower("DartlingGunner", 5);

            /*if (!__instance.towerModel.name.Contains("DartlingGunner-5"))
                return;*/


            /*var attackModel = __instance.towerModel.GetAttackModel();
            if (attackModel is null)
                return;

            var weaponBehaviors = attackModel.weapons[0].behaviors;
            var lineEffect = weaponBehaviors[0].TryCast<LineEffect>();

            var newLine = lineEffect.lineEffectModel.;
            newLine.
            foreach (var weapon in weaponBehaviors)
            {
                MelonLogger.Log(weapon.name);
            }*/
        }
    }
}
