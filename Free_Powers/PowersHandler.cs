using Assets.Scripts.Models.Powers;
using Assets.Scripts.Unity;
using Il2CppSystem.Collections.Generic;
using UnhollowerBaseLib;
using System;
using MelonLoader;

namespace Free_Powers
{
    internal class PowersHandler
    {
        public Dictionary<PowerModel, int> defaultPowerCosts;

        public Il2CppReferenceArray<PowerModel> GetAllPowers() => Game.instance.model.powers;

        public void ResetAllPowerCosts() => SetAllPowerCost(reset: true);

        public void SetAllPowersFree() => SetAllPowerCost(cost:0);


        public void SetAllPowerCost(int cost = 0, bool reset = false)
        {
            var powers = GetAllPowers();
            if (powers is null)
                return;

            for (int i = 0; i < powers.Count; i++)
            {
                var power = powers[i];

                power.cost = (reset) ? defaultPowerCosts[power] : cost;
            }
        }

        public void InitDefaultCostDictionary()
        {
            var powers = GetAllPowers();
            if (powers is null)
                return;

            defaultPowerCosts = new Dictionary<PowerModel, int>();
            for (int i = 0; i < powers.Count; i++)
            {
                var power = powers[i];
                defaultPowerCosts[power] = power.cost;
            }
        }
    }
}