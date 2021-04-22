using Assets.Scripts.Models.Towers;
using Assets.Scripts.Simulation;
using Assets.Scripts.Unity.UI_New.InGame;
using Harmony;
using BloonsTD6_Mod_Helper.Extensions;
using Assets.Scripts.Models.Towers.Behaviors.Attack;
using Assets.Scripts.Models.Towers.Projectiles.Behaviors;
using MelonLoader;

namespace Random_Tower_Speed_and_Range.Patches
{

    [HarmonyPatch(typeof(Simulation), nameof(Simulation.OnRoundStart))]
    internal class Simulation_OnRoundStart
    {
        [HarmonyPostfix]
        internal static void Postfix(Simulation __instance)
        {
            if (SessionData.CurrentSession.IsCheating)
                return;

            var settings = Settings.LoadedSettings;
            var session = SessionData.CurrentSession;

            session.RoundSinceLastRandom++;
            if (session.RoundSinceLastRandom < settings.NumRoundsBeforeRandom)
                return;

            var towerSims = InGame.instance?.GetTowers();
            if (towerSims is null || towerSims.Count == 0)
                return;

            foreach (var towerSim in towerSims)
            {
                var tower = towerSim?.tower;
                if (tower is null)
                    continue;

                var tModelClone = tower.towerModel.Clone().TryCast<TowerModel>();
                if (tModelClone is null)
                    continue;

                if (!tModelClone.HasBehavior<AttackModel>())
                    continue;

                var attackModels = tModelClone.GetBehaviors<AttackModel>();
                if (attackModels is null || attackModels.Count == 0)
                    continue;

                bool madeChange = false;
                foreach (var attackModel in attackModels)
                {
                    madeChange = false;

                    if (attackModel is null)
                        continue;

                    if (settings.EnableRandomRange)
                    {
                        madeChange = true;
                        var newRange = session.TowerModifier.GetRandomRange();
                        attackModel.range = newRange;
                        tModelClone.range = newRange;
                    }

                    foreach (var weaponModel in attackModel.weapons)
                    {
                        if (weaponModel is null)
                            continue;

                        if (settings.EnableRandomSpeed)
                        {
                            madeChange = true;
                            var newSpeed = session.TowerModifier.GetRandomSpeed();
                            weaponModel.rate = newSpeed;
                        }
                        
                        if (settings.EnableRandomRange && tModelClone.isGlobalRange == false)
                        {
                            if (weaponModel.projectile.HasBehavior<TravelStraitModel>())
                            {
                                var travelStraight = weaponModel.projectile.GetBehavior<TravelStraitModel>();
                                if (travelStraight != null)
                                {
                                    travelStraight.lifespan = attackModel.range;
                                    madeChange = true;
                                }
                            }   
                        }
                    }
                }

                if (madeChange)
                    tower.UpdateRootModel(tModelClone);
            }

            session.RoundSinceLastRandom = 0;
        }
    }
}
