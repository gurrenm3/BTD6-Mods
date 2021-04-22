using Assets.Scripts.Models.Profile;
using Assets.Scripts.Models.Towers.Upgrades;
using Assets.Scripts.Unity;
using MelonLoader;
using Gurren_Core.Extensions;

namespace Towers_Randomly_Promoted.Extensions
{
    public static class UpgradeModelExt
    {
        public static bool? IsUpgradeUnlocked(this UpgradeModel upgradeModel)
        {
            return Game.instance.GetBtd6Player()?.HasUpgrade(upgradeModel.name);
        }
    }
}
