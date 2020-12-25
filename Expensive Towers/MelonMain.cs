using Assets.Scripts.Unity;
using Assets.Scripts.Unity.UI_New.InGame;
using MelonLoader;
using System;
using System.Reflection;

namespace Expensive_Towers
{
    public class MelonMain : MelonMod
    {
        internal static string modDir = $"{Environment.CurrentDirectory}\\Mods\\{Assembly.GetExecutingAssembly().GetName().Name}";

        public override void OnApplicationStart()
        {
            MelonLogger.Log("Mod has finished loading");
            MelonLogger.Log("You can change how expensive towers are in the settings file, located" +
                " in \"BloonsTD6/Mods/Expensive Towers/settings.json\"");
        }

        public override void OnUpdate()
        {
            if (Game.instance is null)
                return;

            if (InGame.instance is null)
                return;

        }
    }
}