using Assets.Scripts.Models;
using Assets.Scripts.Simulation.Bloons;
using Gurren_Core.Api.BTD6;
using Harmony;

namespace Baby_Mode.Patches
{
    [HarmonyPatch(typeof(Bloon), "Initialise")]
    public class Bloon_Initialise
    {
        [HarmonyPostfix]
        public static void Postfix(Bloon __instance, ref Model modelToUse)
        {
            if (SessionData.CurrentSession.IsCheating)
                return;

            var settings = Settings.LoadedSettings;
            __instance.bloonModel = _BloonModel.SetBloonStatus(modelToUse.name, settings.AllowCamo, settings.AllowFortified, settings.AllowRegrow);
        }
    }
}