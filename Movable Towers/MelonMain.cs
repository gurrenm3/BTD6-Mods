using Assets.Scripts.Unity;
using Assets.Scripts.Unity.UI_New.InGame;
using MelonLoader;
using System;
using System.Reflection;
using UnityEngine;

namespace Movable_Towers
{
    public class MelonMain : MelonMod
    {
        internal static string modDir = $"{Environment.CurrentDirectory}\\Mods\\{Assembly.GetExecutingAssembly().GetName().Name}";
        internal static KeyCode moveKey = KeyCode.LeftShift;

        public override void OnApplicationStart()
        {
            MelonLogger.Log("Mod has finished loading");

            string modName = Assembly.GetExecutingAssembly().GetName().Name;
            MelonLogger.Log($"{modName} will not work in Races, Odyssey, and Public Co-op matches. This is for your own" +
                $" protection so you're account doesn't get in trouble.");
        }

        public override void OnUpdate()
        {
            if (Game.instance is null)
                return;

            if (InGame.instance is null)
                return;

            if (!SessionData.CurrentSession.MoveKeyHeld)
            {
                var pressed = Input.GetKeyDown(moveKey);
                if (pressed)
                    SessionData.CurrentSession.MoveKeyHeld = true;
            }
            else
            {
                var released = Input.GetMouseButton(0);
                if (released)
                    SessionData.CurrentSession.MoveKeyHeld = false;
            }
            /*else
            {
                var released = Input.GetKeyUp(moveKey);
                if (released)
                    SessionData.CurrentSession.MoveKeyHeld = false;
            }*/
        }
    }
}