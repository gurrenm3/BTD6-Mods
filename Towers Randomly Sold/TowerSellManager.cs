using Assets.Scripts.Unity.Bridge;
using Assets.Scripts.Unity.UI_New.InGame;
using System;
using UnityEngine;

namespace Towers_Randomly_Sold
{
    class TowerSellManager
    {
        System.Random rand = new System.Random();
        float? timeToNextSell;

        public TowerSellManager()
        {
            SetNextSellTime();
        }

        public bool CanSellTower()
        {
            return Time.time >= timeToNextSell;
        }

        private void SetNextSellTime()
        {
            timeToNextSell = Time.time + rand.Next(Settings.LoadedSettings.MinSellTime, Settings.LoadedSettings.MaxSellTime);
        }

        public void SellRandomTower()
        {
            var towerToSell = GetRandomTower();
            SellTower(towerToSell);
            SetNextSellTime();
        }

        private void SellTower(TowerToSimulation tower) => InGame.instance.SellTower(tower);

        private TowerToSimulation GetRandomTower()
        {
            var towers = InGame.Bridge.GetAllTowers();
            var randomIndex = rand.Next(0, towers.Count);
            var tower = towers[randomIndex];
            return tower;
        }
    }
}
