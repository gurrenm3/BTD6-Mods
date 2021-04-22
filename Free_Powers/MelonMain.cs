using Assets.Scripts.Unity;
using MelonLoader;
using System;
using System.Reflection;

namespace Free_Powers
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
            if (Game.instance is null || Game.instance.model is null || Game.instance.model.powers is null)
                return;

            if (SessionData.CurrentSession.PowersManager.defaultPowerCosts is null)
                SessionData.CurrentSession.PowersManager.InitDefaultCostDictionary();
        }
    }
}