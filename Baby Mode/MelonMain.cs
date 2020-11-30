using MelonLoader;
using Assets.Scripts.Unity;
using Assets.Scripts.Unity.UI_New.InGame;
using Gurren_Core.Logging;
using Baby_Mode.Enums;
using System;
using System.Reflection;

namespace Baby_Mode
{
    internal class MelonMain : MelonMod
    {
        internal static bool isInRace = false;
        internal static bool setPrices = false;
        internal static bool shownInGameMsg = false;
        internal static string modDir = Environment.CurrentDirectory + "//Mods//" + Assembly.GetExecutingAssembly().GetName().Name;

        public override void OnApplicationStart()
        {
            base.OnApplicationStart();
            MelonLogger.Log("Baby mode has loaded!");
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            if (Game.instance == null || InGame.instance == null)
                return;

            if (isInRace)
            {
                HandleRaces();
                return;
            }

            if (!setPrices)
            {
                SetTowerPrices(2, MathType.Divide);
                setPrices = true;
            }
        }

        private void HandleRaces()
        {
            if (!shownInGameMsg)
            {
                Logger.ShowMessage("Notice! Baby mode is disabled in Races because it's cheating...", displayTime: 5);
                shownInGameMsg = true;
            }

            if (setPrices)
            {
                SetTowerPrices(2, MathType.Multiply);
                setPrices = false;
            }
        }

        private void SetTowerPrices(int modifier, MathType modifierType)
        {
            foreach (var tower in Game.instance.model.towers)
            {
                if (modifierType == MathType.Multiply)
                    tower.cost *= modifier;
                else
                    tower.cost /= modifier;
            }

            foreach (var upgrade in Game.instance.model.upgrades)
            {
                if (modifierType == MathType.Multiply)
                    upgrade.cost *= modifier;
                else
                    upgrade.cost /= modifier;
            }
        }
    }
}
