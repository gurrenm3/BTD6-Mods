using Assets.Scripts.Simulation.Towers;
using Harmony;
using BloonsTD6_Mod_Helper.Extensions;
using MelonLoader;
using Assets.Scripts.Unity;

namespace Ultimate_Ray_of_Doom.Patches
{
    [HarmonyPatch(typeof(Tower), nameof(Tower.UpdatedModel))]
    internal class Tower_UpdatedModel
    {
        [HarmonyPostfix]
        internal static void Postfix(ref Tower __instance)
        {
            if (SessionData.CurrentSession.IsCheating)
                return;

            /*__instance.towerModel = Game.instance.model.GetTower("DartlingGunner", 5);

            *//*if (!__instance.towerModel.name.Contains("DartlingGunner-5"))
                return;*//*

            var attackModel = __instance.towerModel.GetAttackModel();
            if (attackModel is null)
                return;

            foreach (var weapon in attackModel.weapons)
            {
                MelonLogger.Log(weapon.name);
            }*/
        }
    }
}
