using Aim_All_Towers.Utils;
using Assets.Scripts.Models;
using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Behaviors.Attack;
using MelonLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using UnhollowerBaseLib;

namespace Aim_All_Towers.Extensions
{
    public static class TowerModelExt
    {
        public static List<AttackModel> GetAttackModel(this TowerModel towerModel)
        {
            if (!towerModel.HasBehavior<AttackModel>())
                return null;

            return towerModel.GetBehavior<AttackModel>();
        }

        public static bool HasBehavior<T>(this TowerModel towerModel) where T : TowerBehaviorModel
        {
            if (towerModel.behaviors == null || towerModel.behaviors.Count == 0)
                return false;

            try { var result = towerModel.behaviors.First(item => item.name.Contains(typeof(T).Name)); }
            catch (InvalidOperationException) { return false; }

            return true;
        }

        public static List<T> GetBehavior<T>(this TowerModel towerModel) where T : TowerBehaviorModel
        {
            var behaviors = towerModel.behaviors;
            if (towerModel.behaviors is null || towerModel.behaviors.Count == 0)
                return null;

            var results = new Il2CppReferenceArray<T>(0);
            foreach (var behavior in behaviors)
            {
                if (behavior.name.Contains(typeof(T).Name))
                    Il2CppUtils.Add<T>(results, behavior.TryCast<T>());
            }
            //var result = behaviors.FirstOrDefault(behavior => behavior.name.Contains(typeof(T).Name)); //removed to use List instead

            return results.ToList();
        }

        public static void RemoveBehavior<T>(this TowerModel towerModel) where T : TowerBehaviorModel
        {
            if (!towerModel.HasBehavior<T>())
                return;

            var behaviors = towerModel.GetBehavior<T>();
            foreach (var item in behaviors)
                towerModel.RemoveBehavior(item);
        }

        public static void RemoveBehavior<T>(this TowerModel towerModel, T behavior) where T : TowerBehaviorModel
        {
            if (!towerModel.HasBehavior<T>())
                return;

            int itemsRemoved = 0;
            var behaviors = towerModel.behaviors;
            towerModel.behaviors = new Il2CppReferenceArray<Model>(behaviors.Length - 1);

            for (int i = 0; i < behaviors.Length; i++)
            {
                var item = behaviors[i];
                if (item.name == behavior.name)
                {
                    itemsRemoved++;
                    continue;
                }

                towerModel.behaviors[i - itemsRemoved] = item;
            }
        }
    }
}
