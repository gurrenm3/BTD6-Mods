﻿using Assets.Scripts.Unity.UI_New.Coop;
using Harmony;

namespace Random_Teleporting_Towers.Patches
{
    [HarmonyPatch(typeof(CoopQuickMatchScreen), nameof(CoopQuickMatchScreen.Open))]
    internal class CoopButtonChecker_OnClick
    {
        [HarmonyPostfix]
        internal static void Postfix()
        {
            SessionData.CurrentSession.CoopChecker.IsInPublicCoop = true;
        }
    }
}
