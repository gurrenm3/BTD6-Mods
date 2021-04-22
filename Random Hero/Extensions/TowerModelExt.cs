using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.TowerSets;
using Assets.Scripts.Unity.UI_New.InGame;
using MelonLoader;

namespace Random_Hero.Extensions
{
    public static class TowerModelExt
    {
        public static TowerDetailsModel GetTowerDetailsModel(this TowerModel towerModel)
        {
            var allTowerDetails = InGame.instance.GetAllTowerDetailModels();            
            for (int i = 0; i < allTowerDetails.Count; i++)
            {
                var towerDetailModel = allTowerDetails[i];
                if (towerDetailModel is null)
                    continue;

                if (towerDetailModel.towerId.ToLower() == towerModel.name.ToLower())
                    return towerDetailModel;
            }

            return null;
        }
    }
}
