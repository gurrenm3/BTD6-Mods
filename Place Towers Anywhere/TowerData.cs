using Assets.Scripts.Models.Map;
using Assets.Scripts.Models.Towers;
using UnhollowerBaseLib;
using System.Linq;

namespace Place_Towers_Anywhere
{
    class TowerData
    {
        public TowerModel TowerModel { get; set; }
        public float Radius { get; set; }
        public float RadiusSquared { get; set; }
        public Il2CppStructArray<AreaType> AreaTypes { get; set; }


        public void ModTowerModel(TowerModel towerModel)
        {
            SetTowerModelRadius(towerModel);
            SetTowerModelAreaTypes(towerModel);
        }

        public void UnModTowerModel(TowerModel towerModel)
        {
            var towerData = SessionData.CurrentSession.AllTowerData.First(data => data.TowerModel == towerModel);
            if (towerData is null)
                return;

            towerModel.radius = towerData.Radius;
            towerModel.radiusSquared = towerData.RadiusSquared;
            towerModel.areaTypes = towerData.AreaTypes;
        }


        private void SetTowerModelRadius(TowerModel towerModel)
        {
            towerModel.radius = 0;
            towerModel.radiusSquared = 0;
        }

        private void SetTowerModelAreaTypes(TowerModel towerModel)
        {
            towerModel.areaTypes = new UnhollowerBaseLib.Il2CppStructArray<AreaType>(4);

            var areaTypes = towerModel.areaTypes;
            areaTypes[0] = AreaType.ice;
            areaTypes[1] = AreaType.land;
            areaTypes[2] = AreaType.water;
            areaTypes[2] = AreaType.track;
        }
    }
}
