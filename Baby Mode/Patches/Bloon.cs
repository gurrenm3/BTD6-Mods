using Assets.Scripts.Models;
using Assets.Scripts.Simulation.Bloons;
using Gurren_Core.Api.BTD6;
using Harmony;

namespace Baby_Mode.Patches
{
    [HarmonyPatch(typeof(Bloon), "Initialise")]
    public class BloonInitialise_Patch
    {
        private static Settings settings;
        [HarmonyPostfix]
        public static void Postfix(Bloon __instance, ref Model modelToUse)
        {
            if (MelonMain.isInRace)
                return;

            if (settings == null)
                settings = Settings.settings;

            __instance.bloonModel = _BloonModel.SetBloonStatus(modelToUse.name, settings.AllowCamo, settings.AllowFortified, settings.AllowRegrow);
        }
    }
}
