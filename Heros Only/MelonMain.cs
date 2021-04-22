using Assets.Scripts.Unity;
using Assets.Scripts.Unity.UI_New.InGame;
using MelonLoader;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Heros_Only
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

            MelonLogger.Log($"A settings file was created for {modName}. You can change the settings file to allow some" +
                $" towers to work with Heros Only");
        }


        bool createdTowerList = false;
        public override void OnUpdate()
        {
            if (Game.instance is null)
                return;

            if (!createdTowerList)
                CreateTowerList();
        }


        public void CreateTowerList()
        {
            var allTowerTypes = Game.instance?.model?.towers;
            if (allTowerTypes is null)
                return;

            Directory.CreateDirectory(modDir);
            string towerListPath = modDir + "\\all tower types.txt";

            if (File.Exists(towerListPath))
                File.Delete(towerListPath);

            string output = "=====================================================================================================" +
                "\nThis list contains all of the possible Tower types in BTD6. Use this for reference when changing settings." +
                "\nDon't modify this list. If anything goes wrong with this list, delete it and restart BTD6. It will be regenerated." +
                "\n====================================================================================================\n\n";

            List<string> addedTowers = new List<string>();
            foreach (var tower in allTowerTypes)
            {
                if (!addedTowers.Contains(tower.baseId))
                    addedTowers.Add(tower.baseId);
            }

            addedTowers.Sort();
            foreach (var tower in addedTowers)
                output += tower + "\n";

            File.WriteAllText(towerListPath, output);
            MelonLogger.Log("A list with all possible Tower types has been created. It can be found at \"" + towerListPath + "\"");

            createdTowerList = true;
        }
    }
}