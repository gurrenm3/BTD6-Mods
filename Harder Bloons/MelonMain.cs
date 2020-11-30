using MelonLoader;
using System;
using System.Reflection;

namespace Harder_Bloons
{
    public class MelonMain : MelonMod
    {
        internal static string modDir = Environment.CurrentDirectory + "//Mods//" + Assembly.GetExecutingAssembly().GetName().Name;

        public override void OnApplicationStart()
        {
            base.OnApplicationStart();
            MelonLogger.Log("Mod has successfully loaded!");
        }
    }
}
