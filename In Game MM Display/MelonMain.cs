using Assets.Scripts.Unity;
using Assets.Scripts.Unity.UI_New.InGame;
using Assets.Scripts.Unity.UI_New.InGame.Stats;
using Gurren_Core.Extensions;
using MelonLoader;
using System;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

namespace In_Game_MM_Display
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
            if (Game.instance == null || InGame.instance == null || InGame.Bridge == null)
            {
                HideMMDisplay();
                return;
            }

            bool allowInSandbox = Settings.LoadedSettings.ShowInSandbox;
            if (!allowInSandbox && InGame.instance.IsSandbox)
            {
                HideMMDisplay();
                return;
            }


            if (SessionData.mmDisplay is null)
                CreateMMDisplay();

            ShowMMDisplay();
        }

        private void HideMMDisplay()
        {
            if (SessionData.mmDisplay != null)
                SessionData.mmDisplay.SetActive(false);
        }

        private void ShowMMDisplay()
        {
            if (!SessionData.mmDisplay.active)
                SessionData.mmDisplay.SetActive(true);

            SessionData.mmDisplay.GetComponentInChildren<Text>().text = Game.instance.GetMonkeyMoney().ToString();
        }

        private void CreateMMDisplay()
        {
            var resource = Properties.Resources.monkeymoneydisplay;
            SessionData.assetBundle = AssetBundle.LoadFromMemory(resource);

            var canvas = SessionData.assetBundle.LoadAsset("Canvas").Cast<GameObject>();
            SessionData.mmDisplay = GameObject.Instantiate(canvas);
        }        
    }
}