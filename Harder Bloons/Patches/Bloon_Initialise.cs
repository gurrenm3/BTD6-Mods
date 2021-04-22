using Assets.Scripts.Models;
using Assets.Scripts.Models.Bloons;
using Assets.Scripts.Simulation.Bloons;
using Assets.Scripts.Unity;
using Gurren_Core.Extensions;
using Harmony;
using System;
using System.Collections.Generic;

namespace Harder_Bloons.Patches
{
    [HarmonyPatch(typeof(Bloon), "Initialise")]
    internal class Bloon_Initialise
    {
        private Settings settings;
        static Bloon_Initialise patch = new Bloon_Initialise();
        private static Random rand = new Random();

        [HarmonyPostfix]
        internal static void Postfix(Bloon __instance, ref Model modelToUse)
        {
            patch.PatchSetup();

            var newBloon = patch.GetNextBloon(__instance.bloonModel);

            if (newBloon != null)
                __instance.bloonModel = newBloon;
        }

        private void PatchSetup()
        {
            settings = Settings.LoadedSettings;
        }

        private BloonModel GetNextBloon(BloonModel currentBloon)
        {
            BloonModel newModel = currentBloon;

            if (!settings.UseRandomlyStrongerBloons)
            {
                newModel.SetBloonModel(settings.ForceAllBloonsCamo, settings.ForceAllBloonsFortified, settings.ForceAllBloonsRegrow);
            }
            else if (Settings.LoadedSettings.RandomizeBloonsEveryRound)
            {
                if (Simulation_OnRoundEnd.randomizedBloons.Count > 0)
                {
                    Simulation_OnRoundEnd.randomizedBloons.TryGetValue(currentBloon.name, out var tempModel);
                    if (tempModel != null)
                        newModel = tempModel;
                }
            }
            else
            {
                if (IsBloonRandom())
                    newModel = GetRandomBloon(currentBloon);
            }

            return newModel;
        }

        private bool IsBloonRandom()
        {
            int chance = rand.Next(1, settings.ChanceForRandomStrongerBloons + 1); //adding one so the max can be the random number
            return chance == settings.ChanceForRandomStrongerBloons;
        }

        private BloonModel GetRandomBloon(BloonModel currentBloon)
        {
            var randBloonNum = GetRandomBloonNum(currentBloon);
            var allBloonTypes = Game.instance.GetAllBloonModels();
            var randBloonModel = allBloonTypes[randBloonNum];
            var nextBloon = randBloonModel.GetNextStrongest(settings.AllowRandomCamos, settings.AllowRandomFortified, settings.AllowRandomRegrows);

            return nextBloon;
        }

        private int GetRandomBloonNum(BloonModel currentBloon)
        {
            var allBloonTypes = Game.instance.GetAllBloonModels();
            int maxBloonNum = allBloonTypes.Count - 2; //subtracting 2 to avoid test bloon
            int maxRand = (settings.maxRandomChange > 0) ? settings.maxRandomChange : 0;
            var randNum = rand.Next(0, maxRand);

            var currentBloonNum = currentBloon.GetBloonIdNum();
            var nextPossibleBloonNum = currentBloonNum + randNum;
            var nextBloonNum = (nextPossibleBloonNum <= maxBloonNum) ? nextPossibleBloonNum : maxBloonNum;

            return nextBloonNum;
        }
    }
}
