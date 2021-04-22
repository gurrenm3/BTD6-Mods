using Assets.Scripts.Models;
using Assets.Scripts.Models.Towers.Behaviors.Attack;
using System.Linq;
using UnhollowerBaseLib;
using MelonLoader;
using System;
using Aim_All_Towers.Utils;
using System.Collections.Generic;

namespace Aim_All_Towers.Extensions
{
    public static class AttackModelExt
    {
        public static bool HasBehavior<T>(this AttackModel attackModel) where T : AttackBehaviorModel
        {
            if (attackModel.behaviors == null ||  attackModel.behaviors.Count == 0)
                return false;

            try { var result = attackModel.behaviors.First(item => item.name.Contains(typeof(T).Name)); }
            catch (Exception) { return false; }

            return true;
        }

        public static List<T> GetBehavior<T>(this AttackModel attackModel) where T : AttackBehaviorModel
        {
            var behaviors = attackModel.behaviors;
            if (attackModel.behaviors is null || attackModel.behaviors.Count == 0)
                return null;

            var results = new Il2CppReferenceArray<T>(0);
            foreach (var behavior in behaviors)
            {
                if (behavior.name.Contains(typeof(T).Name))
                {
                    Il2CppUtils.Add<T>(results, behavior.TryCast<T>());
                }
            }
            //var result = behaviors.FirstOrDefault(behavior => behavior.name.Contains(typeof(T).Name));

            return results.ToList();
        }

        public static void AddBehavior<T>(this AttackModel attackModel, T behavior) where T : AttackBehaviorModel
        {
            attackModel.behaviors = Il2CppUtils.Add(attackModel.behaviors, behavior);
        }

        public static void RemoveBehavior<T>(this AttackModel attackModel) where T : AttackBehaviorModel
        {
            if (!attackModel.HasBehavior<T>())
                return;

            var behaviors = attackModel.GetBehavior<T>();
            foreach (var item in behaviors)
                attackModel.RemoveBehavior(item);
        }

        public static void RemoveBehavior<T>(this AttackModel attackModel, T behavior) where T : AttackBehaviorModel
        {
            if (!attackModel.HasBehavior<T>())
                return;

            bool foundItem = false;
            var behaviors = attackModel.behaviors;
            attackModel.behaviors = new Il2CppReferenceArray<Model>(behaviors.Length - 1);

            for (int i = 0; i < behaviors.Length; i++)
            {
                var item = behaviors[i];
                if (item.name == behavior.name)
                {
                    foundItem = true;
                    continue;
                }

                int index = (foundItem) ? i - 1 : i;
                attackModel.behaviors[index] = item;
            }
        }
    }
}
