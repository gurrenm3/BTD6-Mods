using Assets.Scripts.Unity;
using Assets.Scripts.Unity.UI_New.InGame;
using MelonLoader;
using System;
using System.Reflection;

namespace Aim_All_Towers
{
    public class MelonMain : MelonMod
    {
        internal static string modDir = $"{Environment.CurrentDirectory}\\Mods\\{Assembly.GetExecutingAssembly().GetName().Name}";

        public override void OnApplicationStart()
        {
            MelonLogger.Log("Mod has finished loading");

            string modName = Assembly.GetExecutingAssembly().GetName().Name;
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