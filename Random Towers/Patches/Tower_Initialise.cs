using Assets.Scripts.Models;
using Assets.Scripts.Models.Towers;
using Assets.Scripts.Simulation.Towers;
using Assets.Scripts.Unity;
using Harmony;
using MelonLoader;
using System;

namespace Random_Towers.Patches
{
    [HarmonyPatch(typeof(Tower), nameof(Tower.Initialise))]
    internal class Tower_Initialise
    {

        [HarmonyPrefix]
        internal static bool Prefix(ref Tower __instance, ref Model modelToUse)
        {
            if (SessionData.CurrentSession.IsCheating)
                return true;

            var settings = Settings.LoadedSettings;

            if (!settings.RandomizeTowerWhenPlaced)
                return true;

            if (!settings.AllowedTowers.Contains(modelToUse.name))
                return true;

            try
            {
                var newModel = TowerRandomizer.instance.GetRandomTower();
                if (newModel != null)
                {
                    MelonLogger.Log($"New tower model: {newModel.name}");
                    var model = newModel.TryCast<Model>();
                    if (model != null)
                        modelToUse = model;
                }
            }
            catch (Exception)
            {}
            return true;
        }
    }
}