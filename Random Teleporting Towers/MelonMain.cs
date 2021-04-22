using Assets.Scripts.Models.Towers;
using Assets.Scripts.Simulation.SMath;
using Assets.Scripts.Unity;
using Assets.Scripts.Unity.Bridge;
using Assets.Scripts.Unity.UI_New.InGame;
using MelonLoader;
using System;
using System.Reflection;
using UnityEngine;
using Vector2 = Assets.Scripts.Simulation.SMath.Vector2;

namespace Random_Teleporting_Towers
{
    public class MelonMain : MelonMod
    {
        internal static string modDir = $"{Environment.CurrentDirectory}\\Mods\\{Assembly.GetExecutingAssembly().GetName().Name}";

        public override void OnApplicationStart()
        {
            MelonLogger.Log("Mod has finished loading");

            string modName = Assembly.GetExecutingAssembly().GetName().Name;
            MelonLogger.Log($"{modName} will not work in Races, Odyssey, and Public Co-op matches. This is for your own" +
                $" protection so you're account doesn't get in trouble.");
        }

        public override void OnUpdate()
        {
            if (Game.instance is null)
                return;

            if (InGame.instance?.bridge is null)
                return;

            if (!Settings.LoadedSettings.TeleportAfterTime)
                return;

            if (InGame.instance.IsSandbox && !Settings.LoadedSettings.WorkInSandbox)
                return;

            if (Time.time < SessionData.CurrentSession.TimeToNextRandom)
                return;

            if (!InGame.instance.bridge.AreRoundsActive())
            {
                var min1 = Settings.LoadedSettings.MinTimeBeforeTeleport;
                var max2 = Settings.LoadedSettings.MaxTimeBeforeTeleport;
                var nextRandom2 = SessionData.CurrentSession.Rand.Next(min1, max2);
                SessionData.CurrentSession.TimeToNextRandom = (int)Time.time + nextRandom2;
                return;
            }

            var teleporter = SessionData.CurrentSession.Teleporter;
            teleporter.TeleportAllTowers();

            var min = Settings.LoadedSettings.MinTimeBeforeTeleport;
            var max = Settings.LoadedSettings.MaxTimeBeforeTeleport;
            var nextRandom = SessionData.CurrentSession.Rand.Next(min, max);
            SessionData.CurrentSession.TimeToNextRandom = (int)Time.time + nextRandom;
        }
    }
}