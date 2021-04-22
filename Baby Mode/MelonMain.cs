using Assets.Scripts.Unity;
using Assets.Scripts.Unity.UI_New.InGame;
using Baby_Mode.Enums;
using MelonLoader;
using System;
using System.Reflection;

namespace Baby_Mode
{
    public class MelonMain : MelonMod
    {
        internal static string modDir = $"{Environment.CurrentDirectory}\\Mods\\{Assembly.GetExecutingAssembly().GetName().Name}";
        bool setPrices = false;

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

            bool isCheating = SessionData.CurrentSession.IsCheating;
            if (isCheating && setPrices)
            {
                TowerModifier.SetTowerPrices(2, MathType.Multiply);
                setPrices = false;
            }

            if (!isCheating && !setPrices)
            {
                TowerModifier.SetTowerPrices(2, MathType.Divide);
                setPrices = true;
            }
        }
    }
}