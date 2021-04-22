using Assets.Scripts.Unity;
using Aim_All_Towers.Extensions;
using Assets.Scripts.Models.Towers.Behaviors.Attack.Behaviors;
using MelonLoader;
using Assets.Scripts.Models.Towers.Behaviors.Attack;
using System.IO;
using System;
using System.Collections.Generic;
using Assets.Scripts.Models.Towers;

namespace Aim_All_Towers
{
    class TowerModifier
    {
        TargetPointerModel targetPointerModel;
        TargetSelectedPointModel targetSelectedPointModel;
        RotateToPointerModel rotateToPointer;
        public void ModAllTowers()
        {
            var allTowerModels = Game.instance.model.towers;

            var dartlingGunner = Game.instance.model.GetTower("DartlingGunner");
            var dartlingAttackModel = dartlingGunner.GetAttackModel();

            targetPointerModel = dartlingAttackModel[0].GetBehavior<TargetPointerModel>()[0];
            targetSelectedPointModel = dartlingAttackModel[0].GetBehavior<TargetSelectedPointModel>()[0];
            rotateToPointer = dartlingAttackModel[0].GetBehavior<RotateToPointerModel>()[0];

            rotateToPointer.rate *= 5.5f;

            for (int i = 0; i < allTowerModels.Length; i++)
            {
                TowerModel towerModel = allTowerModels[i];
                if (ShouldSkipTower(towerModel, out AttackModel attackModel))
                    continue;

                /*foreach (var model in towerModel.GetBehavior<AttackModel>())
                {
                    
                }*/

                RemoveTargetingBehaviors(attackModel);
                AddAimingBehaviors(attackModel);
            }
        }

        private bool ShouldSkipTower(TowerModel towerModel, out AttackModel attackModel)
        {
            attackModel = towerModel.GetAttackModel()[0];
            if (attackModel is null)
                return true;

            if (towerModel.name.Contains("SuperMonkey-401"))
                return true;

            if (towerModel.baseId == "SniperMonkey")
                return true;

            if (towerModel.baseId == "HeliPilot")
                return true;            

            if (towerModel.baseId.Contains("Mortar"))
                return true;

            if (towerModel.name.Contains("MonkeyVillage-5"))
                return true;

            if (towerModel.name.Contains("WizardMonkey-5"))
                return true;

            if (towerModel.name.Contains("Druid-200"))
                return true;

            return false;
        }

        private void AddAimingBehaviors(AttackModel attackModel)
        {
            if (!attackModel.HasBehavior<TargetPointerModel>())
                attackModel.AddBehavior(targetPointerModel);

            if (!attackModel.HasBehavior<TargetSelectedPointModel>())
                attackModel.AddBehavior(targetSelectedPointModel);

            if (!attackModel.HasBehavior<RotateToPointerModel>())
                attackModel.AddBehavior(rotateToPointer);
        }

        private void RemoveTargetingBehaviors(AttackModel attackModel)
        {
            attackModel.RemoveBehavior<TargetIndependantModel>();
            attackModel.RemoveBehavior<TargetFirstModel>();
            attackModel.RemoveBehavior<TargetStrongModel>();
            attackModel.RemoveBehavior<TargetCloseModel>();
            attackModel.RemoveBehavior<TargetLastModel>();
            attackModel.RemoveBehavior<RotateToTargetModel>();
        }
    }
}
