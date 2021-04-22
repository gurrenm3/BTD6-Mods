using Assets.Scripts.Unity;
using Assets.Scripts.Unity.UI_New.InGame;
using MelonLoader;
using System;
using System.Reflection;
using UnityEngine;
using static Quick_Sell_Towers.SessionData;

namespace Quick_Sell_Towers
{
    public class MelonMain : MelonMod
    {
        internal static string modDir = $"{Environment.CurrentDirectory}\\Mods\\{Assembly.GetExecutingAssembly().GetName().Name}";
        internal static KeyCode sellKey = KeyCode.Delete;

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


            if (!sellKeyHeld)
            {
                var pressed = Input.GetKeyDown(sellKey);
                if (pressed)
                    sellKeyHeld = true;
            }
            else
            {
                var released = Input.GetKeyUp(sellKey);
                if (released)
                    sellKeyHeld = false;
            }
        }
    }
}