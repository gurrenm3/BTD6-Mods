using Assets.Scripts.Simulation.Bloons;
using Harmony;
using Gurren_Core.Extensions;

namespace Normal_Bloons.Patches
{
    [HarmonyPatch(typeof(Bloon), "Initialise")]
    public class Bloon_Initialise
    {
        [HarmonyPostfix]
        public static void Postfix(ref Bloon __instance)
        {
            if (SessionData.CurrentSession.IsCheating)
                return;

            var settings = Settings.LoadedSettings;
            __instance.RemoveBloonStatus(settings.RemoveCamo, settings.RemoveFortify, settings.RemoveRegrow);
        }
    }
}