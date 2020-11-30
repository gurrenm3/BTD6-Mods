namespace Harder_Bloons.Patches.Bloon
{
    using System;
    using Harmony;
    using Assets.Scripts.Unity;
    using Assets.Scripts.Models;
    using Gurren_Core.Extensions;
    using Assets.Scripts.Models.Bloons;
    using Assets.Scripts.Simulation.Bloons;
    using MelonLoader;
    using System.Collections.Generic;

    [HarmonyPatch(typeof(Bloon), "Initialise")]
    internal class Bloon_Initialise_Patch
    {
        private static Settings cfg;
        private static Random rand = new Random();
        private static List<BloonModel> allBloonTypes;

        [HarmonyPostfix]
        internal static void Postfix(Bloon __instance, ref Model modelToUse)
        {
            var patch = new Bloon_Initialise_Patch();
            patch.PatchSetup();

            var newBloon = patch.GetNextBloon(__instance.bloonModel);
            if (newBloon != null)
                __instance.bloonModel = newBloon;
        }

        private void PatchSetup()
        {
            if (cfg is null)
                cfg = Settings.settings;

            if (allBloonTypes == null)
                allBloonTypes = Game.instance.GetAllBloonModels();
        }

        private BloonModel GetNextBloon(BloonModel currentBloon)
        {
            BloonModel newBloon = currentBloon;

            if (!cfg.UseRandomlyStrongerBloons)
            {
                newBloon.SetBloonModel(cfg.ForceAllBloonsCamo, cfg.ForceAllBloonsFortified, cfg.ForceAllBloonsRegrow);
            }
            else
            {
                if (IsBloonRandom())
                    newBloon = GetRandomBloon(currentBloon);
            }

            return newBloon;
        }

        private bool IsBloonRandom()
        {
            int chance = rand.Next(1, cfg.ChanceForRandomStrongerBloons + 1); //adding one so the max can be the random number
            return chance == cfg.ChanceForRandomStrongerBloons;
        }
        
        private BloonModel GetRandomBloon(BloonModel currentBloon)
        {
            var randBloonNum = GetRandomBloonNum(currentBloon);
            var randBloonModel = allBloonTypes[randBloonNum];
            var nextBloon = randBloonModel.GetNextStrongest(cfg.AllowRandomCamos, cfg.AllowRandomFortified, cfg.AllowRandomRegrows);

            return nextBloon;
        }

        private int GetRandomBloonNum(BloonModel currentBloon)
        {
            int maxBloonNum = allBloonTypes.Count - 2; //subtracting 2 to avoid test bloon
            int maxRand = (cfg.maxRandomChange > 0) ? cfg.maxRandomChange : 0;
            var randNum = rand.Next(0, maxRand);

            var currentBloonNum = currentBloon.GetBloonIdNum();
            var nextPossibleBloonNum = currentBloonNum + randNum;
            var nextBloonNum = (nextPossibleBloonNum <= maxBloonNum) ? nextPossibleBloonNum : maxBloonNum;

            return nextBloonNum;
        }
    }
}