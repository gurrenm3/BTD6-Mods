﻿using Assets.Scripts.Unity.UI_New.Main.EventPanel;
using Harmony;

namespace Ultimate_Ray_of_Doom.Patches
{
    [HarmonyPatch(typeof(MainMenuEventPanel), nameof(MainMenuEventPanel.OpenRaceEventScreen))]
    internal class MainMenuEventPanel_OpenRaceEventScreen
    {
        [HarmonyPostfix]
        internal static void Postfix()
        {
            SessionData.CurrentSession.RaceChecker.IsInRace = true;
        }
    }
}