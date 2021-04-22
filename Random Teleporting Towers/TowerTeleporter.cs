using Assets.Scripts.Simulation.SMath;
using Assets.Scripts.Unity.Bridge;
using Assets.Scripts.Unity.UI_New.InGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Random_Teleporting_Towers
{
    class TowerTeleporter
    {
        public void TeleportAllTowers()
        {
            var towerSims = InGame.instance.bridge.GetAllTowers();
            foreach (var towerSim in towerSims)
            {
                TeleportTower(towerSim);
            }
        }

        public void TeleportTower(TowerToSimulation towerToSimulation)
        {
            Vector2 topLeft = new Vector2(-140.9228f, -105.2562f);
            Vector2 bottomRight = new Vector2(140.0713f, 105.4701f);

            var rand = SessionData.CurrentSession.Rand;
            var nextX = rand.Next((int)topLeft.x, (int)bottomRight.x);
            var nextY = rand.Next((int)topLeft.y, (int)bottomRight.y);

            Vector2 newPosition = new Vector2(nextX, nextY);
            towerToSimulation.tower.PositionTower(newPosition);
        }
    }
}
