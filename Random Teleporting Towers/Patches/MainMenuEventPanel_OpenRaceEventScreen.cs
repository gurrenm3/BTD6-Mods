﻿using Assets.Scripts.Unity.UI_New.Main.EventPanel;
using Harmony;

namespace Random_Teleporting_Towers.Patches
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