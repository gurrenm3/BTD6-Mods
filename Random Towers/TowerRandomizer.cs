using Assets.Scripts.Models.Towers;
using Assets.Scripts.Unity;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using MelonLoader;
using System.Linq;

namespace Random_Towers
{
    public class TowerRandomizer : MonoBehaviour
    {
        public static TowerRandomizer instance;
        List<string> AllowedTowerNames = new List<string>();
        //Random rand = new Random();
        readonly Settings settings;

        public List<TowerModel> updatedTowers = new List<TowerModel>();


        public TowerRandomizer()
        {
            instance = this;
            settings = Settings.LoadedSettings;


            var towers = Game.instance.model.towers;
            foreach (var tower in towers)
            {
                if (settings.AllowedTowers.Contains(tower.baseId))
                    AllowedTowerNames.Add(tower.name);
            }
        }


        public TowerModel GetRandomTower()
        {
            string towerName = "";

            if (!settings.AllowRandomUpgrades)
            {
                var next = Random.Range(0, settings.AllowedTowers.Count - 1);
                //var next = rand.Next(settings.AllowedTowers.Count);
                towerName = settings.AllowedTowers[next];
            }
            else
            {
                if (settings.MinimumRandomTier != 0)
                {
                    var list = AllowedTowerNames.Where(t => t.Contains(settings.MinimumRandomTier.ToString()));
                    var next = Random.Range(0, list.Count()-1);
                    //var next = rand.Next(0, list.Count());
                    towerName = list.ElementAt(next);
                }
                else
                {
                    var next = Random.Range(0, AllowedTowerNames.Count - 1);
                    //var next = rand.Next(0, AllowedTowerNames.Count);
                    towerName = AllowedTowerNames[next];
                }
            }

            try
            {
                return Game.instance.model.GetTowerWithName(towerName);
            }
            catch (Exception)
            { return null; }
        }
    }
}
