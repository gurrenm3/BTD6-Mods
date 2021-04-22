using Assets.Scripts.Models.Bloons;
using Assets.Scripts.Simulation;
using Assets.Scripts.Unity;
using Harmony;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloonsTD6_Mod_Helper.Extensions;
using Random = UnityEngine.Random;
using MelonLoader;

namespace Harder_Bloons.Patches
{
    [HarmonyPatch(typeof(Simulation), nameof(Simulation.OnRoundEnd))]
    internal class Simulation_OnRoundEnd
    {
        public static Dictionary<string, BloonModel> randomizedBloons = new Dictionary<string, BloonModel>();
        private static Settings settings;

        [HarmonyPostfix]
        internal static void Postfix()
        {
            settings = Settings.LoadedSettings;
            if (!settings.RandomizeBloonsEveryRound)
                return;

            randomizedBloons = new Dictionary<string, BloonModel>();
            var bloons = Game.instance?.model?.bloons;
            foreach (var bloon in bloons)
            {
                var currentId = bloon.GetIndex();
                if (!currentId.HasValue)
                    continue;

                var nextId = Random.Range(0, settings.maxRandomChange);
                nextId += currentId.Value;
                if (nextId < 0)
                    nextId = 0;

                var newBloonModel = (nextId < bloons.Count) ? bloons[nextId] : bloons[bloons.Count-1];
                if (newBloonModel.isMoab)
                    continue;
                randomizedBloons.Add(bloon.name, newBloonModel);
            }
        }
    }
}