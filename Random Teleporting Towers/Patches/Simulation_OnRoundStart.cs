using Assets.Scripts.Simulation;
using Harmony;

namespace Random_Teleporting_Towers.Patches
{
    [HarmonyPatch(typeof(Simulation), nameof(Simulation.OnRoundStart))]
    internal class Simulation_OnRoundStart
    {
        [HarmonyPostfix]
        internal static void Postfix()
        {
            if (!Settings.LoadedSettings.TeleportAfterRounds)
                return;

            SessionData.CurrentSession.RoundsSinceLastRandom++;
            if (SessionData.CurrentSession.RoundsSinceLastRandom < Settings.LoadedSettings.RoundsBeforeTeleport)
                return;

            var teleporter = SessionData.CurrentSession.Teleporter;
            teleporter.TeleportAllTowers();
            SessionData.CurrentSession.RoundsSinceLastRandom = 0;
        }
    }
}