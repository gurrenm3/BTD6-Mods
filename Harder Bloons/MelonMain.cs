using Assets.Scripts.Unity;
using Assets.Scripts.Unity.UI_New.InGame;
using MelonLoader;
using System;
using System.Reflection;
using UnityEngine;

namespace Harder_Bloons
{
    public class MelonMain : MelonMod
    {
        internal static string modDir = $"{Environment.CurrentDirectory}\\Mods\\{Assembly.GetExecutingAssembly().GetName().Name}";

        public override void OnApplicationStart()
        {
            MelonLogger.Log("Mod has finished loading");
        }

        public override void OnUpdate()
        {
            if (Game.instance is null)
                return;

            if (InGame.instance is null)
                return;

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {

            }
        }
    }
}