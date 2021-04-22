using Assets.Scripts.Models.Towers;
using Assets.Scripts.Simulation;
using Assets.Scripts.Unity;
using Assets.Scripts.Unity.Tasks;
using Assets.Scripts.Unity.UI_New.InGame;
using UnityEngine;
using Harmony;
using MelonLoader;
using System.Collections.Generic;
//using static Random_Towers.Patches.Tower_Initialise;

namespace Random_Towers.Patches
{
    [HarmonyPatch(typeof(Simulation), nameof(Simulation.OnRoundStart))]
    internal class Simulation_OnRoundStart
    {
        [HarmonyPostfix]
        internal static void Postfix()
        {
            // this is disabled for the time being because it randomly crashes
            return;

            /*if (InGame.instance.IsSandbox)
                return;

            if (!Settings.LoadedSettings.RandomizeTowerEvery_X_Rounds)
                return;

            SessionData.CurrentSession.RoundSinceLastRandom++;
            if (SessionData.CurrentSession.RoundSinceLastRandom < Settings.LoadedSettings.NumOfRoundsBeforeRandomize)
                return;

            SessionData.CurrentSession.RandomizeAllTowersFromRounds = true;*/
            /*if (InGame.instance.inputManager.HasSomethingSelected())
                InGame.instance.inputManager.CancelSelection();

            //InGame.instance.bridge.DestroyAllProjectiles(true);
            var towers = InGame.instance.bridge.GetAllTowers();
            foreach (var tower in towers)
            {
                var newModel = TowerRandomizer.instance.GetRandomTower();
                if (newModel != null)
                    tower.tower.UpdateRootModel(newModel);
            }*/

            /*List<PreSellData> preSellData = new List<PreSellData>();
            var towers = InGame.instance.bridge.GetAllTowers();
            foreach (var tower in towers)
            {
                var newPresellData = new PreSellData();
                newPresellData.Position = tower.GetSimPosition();
                newPresellData.AreaPlaceOn = tower.GetSimTower().areaPlacedOn;
                newPresellData.TowerModel = TowerRandomizer.instance.GetRandomTower();
                preSellData.Add(newPresellData);
            }


            InGame.instance.bridge.SellAllTowers();

            foreach (var tower in preSellData)
            {
                var vector = new Assets.Scripts.Simulation.SMath.Vector3(tower.Position);
                InGame.instance.bridge.simulation.towerManager.CreateTower(tower.TowerModel, vector, inputIndex: -1, 
                    tower.AreaPlaceOn, isInstaTower: true);
            }*/


            //SessionData.CurrentSession.RandomizeAllTowersFromRounds = true;


            //
            //StartCoroutine(randomizer.MyCoroutine(towers));

            /*var towers = InGame.instance.bridge.GetAllTowers();
            foreach (var tower in towers)
            {
                TowerModel newTower = randomizer.GetRandomTower();
                if (newTower == null)
                    continue;

                var pos = tower.GetSimPosition();
                var areaPlacedOn = tower.GetSimTower().areaPlacedOn;
                var vector = new Assets.Scripts.Simulation.SMath.Vector3(pos);
                InGame.instance.bridge.simulation.towerManager.CreateTower(newTower, vector, inputIndex: -1, areaPlacedOn, isInstaTower: true);

                tower.GetSimTower().Destroy();
            }*/

            SessionData.CurrentSession.RoundSinceLastRandom = 0;
        }
    }
}