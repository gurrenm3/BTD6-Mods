using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Upgrades;
using Assets.Scripts.Unity;
using Gurren_Core.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace Towers_Randomly_Promoted.Extensions
{
    public static class TowerModelExt
    {
        public static bool? CanUpgradeTo(this TowerModel towerModel, int path, int tier)
        {
            if (towerModel.IsHero())
                return null;

            var upgradeModel = towerModel.GetUpgrade(path, tier);
            if (upgradeModel is null)
                return null;

            var isUnlocked = upgradeModel.IsUpgradeUnlocked();
            if (!isUnlocked.HasValue || isUnlocked.Value == false)
                return true;

            if (towerModel.ReachedMaxUpgradePaths() && !towerModel.IsUpgradePathUsed(path))
                return true;

            return false;
        }

        public static int GetUpgradeLevel(this TowerModel towerModel, int path) => towerModel.tiers[path];

        public static List<UpgradeModel> GetAppliedUpgrades(this TowerModel towerModel)
        {
            List<UpgradeModel> appliedUpgrades = new List<UpgradeModel>();
            var upgradeNames = towerModel.appliedUpgrades;

            foreach (var upgrade in upgradeNames)
            {
                appliedUpgrades.Add(Game.instance?.model?.upgradesByName[upgrade]);
            }

            return appliedUpgrades;
        }

        public static UpgradeModel GetUpgrade(this TowerModel towerModel, int path, int tier)
        {
            if (path < 0 || tier < 0)
                return null;

            int tier1 = (path == 0) ? tier : 0;
            int tier2 = (path == 1) ? tier : 0;
            int tier3 = (path == 2) ? tier : 0;

            var tempTower = Game.instance?.model?.GetTower(towerModel.baseId, tier1, tier2, tier3);
            if (tempTower is null)
                return null;

            const int offset = 1;
            foreach (var upgradeModel in tempTower.GetAppliedUpgrades())
            {
                bool isCorrectPath = (upgradeModel.path == path);
                bool isCorrectTier = (upgradeModel.tier == tier - offset);
                if (!isCorrectPath || !isCorrectTier)
                    continue;

                return upgradeModel;
            }

            return null;
        }

        public static bool? IsTowerUnlocked(this TowerModel towerModel)
        {
            return Game.instance?.GetBtd6Player()?.HasUnlockedTower(towerModel.baseId);
        }

        public static bool? IsUpgradeUnlocked(this TowerModel towerModel, int path, int tier)
        {
            var upgradeModel = towerModel.GetUpgrade(path, tier);
            return Game.instance?.GetBtd6Player()?.HasUpgrade(upgradeModel?.name);
        }

        public static bool IsUpgradePathUsed(this TowerModel towerModel, int path)
        {
            var result = towerModel.GetAppliedUpgrades().FirstOrDefault(upgrade => upgrade.path == path);
            return (result != null);
        }

        public static List<int> GetUsedUpgradePaths(this TowerModel towerModel)
        {
            List<int> usedPaths = new List<int>();
            const int totalPaths = 3;

            for (int i = 1; i < totalPaths; i++)
            {
                if (towerModel.IsUpgradePathUsed(i))
                    usedPaths.Add(i);
            }

            return usedPaths;
        }

        public static bool ReachedMaxUpgradePaths(this TowerModel towerModel)
        {
            int pathCount = towerModel.GetUsedUpgradePaths().Count;
            const int maxPaths = 2;
            return pathCount >= maxPaths;
        }

        public static bool ReachedMaxUpgrades(this TowerModel towerModel)
        {
            var upgrades = towerModel.GetAppliedUpgrades();
            bool isUpgradeTier5 = false;
            bool isUpgradeTier2 = false;
            foreach (var upgrade in upgrades)
            {
                if (upgrade.tier == 5)
                    isUpgradeTier5 = true;

                if (upgrade.tier == 2)
                    isUpgradeTier2 = true;
            }

            return isUpgradeTier5 && isUpgradeTier2;
        }
    }
}