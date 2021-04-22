using Assets.Scripts.Unity;
using Baby_Mode.Enums;

namespace Baby_Mode
{
    internal class TowerModifier
    {
        public static void SetTowerPrices(int modifier, MathType modifierType)
        {
            foreach (var tower in Game.instance.model.towers)
            {
                if (modifierType == MathType.Multiply)
                    tower.cost *= modifier;
                else
                    tower.cost /= modifier;
            }

            foreach (var upgrade in Game.instance.model.upgrades)
            {
                if (modifierType == MathType.Multiply)
                    upgrade.cost *= modifier;
                else
                    upgrade.cost /= modifier;
            }
        }
    }
}