using MelonLoader;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace One_Tower_To_Rule_Them_All
{
    class MelonMain : MelonMod
    {
        public static bool isInRace = false;
        internal static string modDir = Environment.CurrentDirectory + "//Mods//" + Assembly.GetExecutingAssembly().GetName().Name;

        public override void OnApplicationStart()
        {
            base.OnApplicationStart();

            CreateTowerList();
            MelonLogger.Log("One Tower to Rule Them All has finished loading");
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
