using Assets.Scripts.Unity;
using Assets.Scripts.Unity.UI_New.InGame;
using MelonLoader;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace One_Tower_To_Rule_Them_All
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

            CreateTowerList();
        }

        public override void OnUpdate()
        {
            if (Game.instance is null)
                return;

            if (InGame.instance is null)
                return;

        }

        public void CreateTowerList()
        {
            string towerListPath = modDir + "\\all tower types.txt";

            if (!new FileInfo(towerListPath).Directory.Exists)
                Directory.CreateDirectory(new FileInfo(towerListPath).Directory.FullName);
            else
            {
                if (File.Exists(towerListPath))
                    File.Delete(towerListPath);
            }

            List<string> allTowerTypes = new List<string>();
            allTowerTypes.AddRange(TowerTypes.defaultAllowTypes);
            allTowerTypes.AddRange(TowerTypes.defaultIgnoreTowers);

            string output = "=====================================================================================================" +
                "\nThis list contains all of the possible Tower types in BTD6. Use this for reference when changing settings." +
                "\nDon't modify this list. If anything goes wrong with this list, delete it and restart BTD6. It will be regenerated." +
                "\n====================================================================================================\n\n";

            foreach (var item in allTowerTypes)
                output += item + "\n";

            File.WriteAllText(towerListPath, output);
            MelonLogger.Log("A list with all possible Tower types has been created. It can be found at \"" + towerListPath + "\"");
        }
    }
}