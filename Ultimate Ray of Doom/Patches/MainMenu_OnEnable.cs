using Assets.Scripts.Unity;
using Assets.Scripts.Unity.UI_New.Main;
using Harmony;
using BloonsTD6_Mod_Helper.Extensions;
using Assets.Scripts.Models.Towers.Behaviors.Attack;
using MelonLoader;

namespace Ultimate_Ray_of_Doom.Patches
{
    [HarmonyPatch(typeof(MainMenu), nameof(MainMenu.OnEnable))]
    internal class MainMenu_OnEnable
    {
        static bool skipFirst = true;

        [HarmonyPostfix]
        internal static void Postfix()
        {
            if (SessionData.CurrentSession.IsCheating)
            {
                SessionData.CurrentSession.ResetCheatStatus();
            }

            if (skipFirst)
            {
                skipFirst = false;
                return;
            }


            foreach (var tower in Game.instance.model.towers)
            {
                if (!tower.HasBehavior<AttackModel>())
                    continue;

                MelonLogger.Log("");
                MelonLogger.Log(tower.name);
                MelonLogger.Log("");
                var attackModels = tower.GetAttackModels();
                //MelonLogger.Log(attackModels.Count);
                /*for (int i = 0; i < attackModels.Count; i++)
                {
                    var attackModel = attackModels[i];
                    MelonLogger.Log(attackModel.name);
                    MelonLogger.Log("");

                    foreach (var behavior in attackModel.behaviors)
                    {
                        MelonLogger.Log(behavior);
                    }
                }*/

                MelonLogger.Log("");
                MelonLogger.Log("============================================");
                MelonLogger.Log("");
            }
        }
    }
}