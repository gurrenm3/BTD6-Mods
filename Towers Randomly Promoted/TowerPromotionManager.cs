using Assets.Scripts.Models.Towers;
using Assets.Scripts.Unity.Bridge;
using Assets.Scripts.Unity.UI_New.InGame;
using Gurren_Core.Extensions;
using Towers_Randomly_Promoted.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Towers_Randomly_Promoted
{
    class TowerPromotionManager
    {
        System.Random rand = new System.Random();
        float? timeToNextPromotion;

        public TowerPromotionManager()
        {
            SetNextPromoteTime();
        }

        public bool CanPromoteTower() => (Time.time >= timeToNextPromotion);

        private void SetNextPromoteTime()
        {
            timeToNextPromotion = Time.time + rand.Next(Settings.LoadedSettings.MinTimeToPromotion, Settings.LoadedSettings.MaxTimeToPromotion);
        }

        public void PromoteRandomTower()
        {
            const int maxAttempts = 10;
            TowerToSimulation towerToPromote = null;
            for (int i = 0; i < maxAttempts; i++)
            {
                var tempTower = GetRandomTower();
                if (tempTower.Def.ReachedMaxUpgrades())
                    continue;

                towerToPromote = tempTower;
            }

            if (towerToPromote is null)
                return;

            PromoteTower(towerToPromote);
            SetNextPromoteTime();
        }

        private TowerToSimulation GetRandomTower()
        {
            var towers = InGame.Bridge.GetAllTowers();
            var randomIndex = rand.Next(0, towers.Count);
            var tower = towers[randomIndex];
            return tower;
        }

        private void PromoteTower(TowerToSimulation tower)
        {
            TowerModel modelToUse = tower.Def;
            

            bool canPromoteToRandTower = Settings.LoadedSettings.AllowPromoteToDifferentTower;
            if (canPromoteToRandTower)
            {

            }
            else
            {

            }

            tower.tower.towerModel = modelToUse;
        }

        private void GetNextUpgrade(TowerModel towerModel, out int path, out int tier)
        {
            var usedPaths = towerModel.GetUsedUpgradePaths();
            List<int> upgradeLevels = new List<int>();
            for (int i = 0; i < usedPaths.Count; i++)
            {
                if (usedPaths.Contains(i))
                    upgradeLevels.Add(i);
                else
                    upgradeLevels.Add(0);
            }

            int tier1 = towerModel.GetUpgradeLevel(0);
            int tier2 = towerModel.GetUpgradeLevel(1);
            int tier3 = towerModel.GetUpgradeLevel(2);

            var rand = SessionData.CurrentSession.Rand;
            var pathToUpgrade = rand.Next(0, 3);
            
        }

        private void GetRandomUpgrade()
        {

        }
    }
}