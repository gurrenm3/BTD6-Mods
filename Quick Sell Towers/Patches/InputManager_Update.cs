using Assets.Scripts.Unity.UI_New.InGame;
using Harmony;
using static Quick_Sell_Towers.SessionData;

namespace Quick_Sell_Towers.Patches
{
    [HarmonyPatch(typeof(InputManager), nameof(InputManager.Update))]
    internal class InputManager_Update
    {
        [HarmonyPostfix]
        internal static void Postfix(InputManager __instance)
        {
            if (!sellKeyHeld || __instance.SelectedTower == null)
                return;

            var selectedTower = __instance.SelectedTower;
            InGame.instance.SellTower(selectedTower);
        }
    }
}