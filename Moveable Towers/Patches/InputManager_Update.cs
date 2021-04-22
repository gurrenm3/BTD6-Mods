using Assets.Scripts.Simulation.Towers;
using Assets.Scripts.Simulation.Track;
using Assets.Scripts.Unity.UI_New.InGame;
using Harmony;
using MelonLoader;
using static Moveable_Towers.SessionData;

namespace Moveable_Towers.Patches
{

    [HarmonyPatch(typeof(InputManager), nameof(InputManager.Update))]
    internal class InputManager_Update
    {
        [HarmonyPostfix]
        internal static void Postfix(InputManager __instance)
        {
            if (__instance.SelectedTower == null)
                return;

            if (!CurrentSession.MoveKeyHeld)
                return;

            var tower = __instance.SelectedTower.GetSimTower();
            var mousePos = __instance.cursorPositionWorld;
            var newPos = new Assets.Scripts.Simulation.SMath.Vector2(mousePos);

            tower.PositionTower(newPos);
        }
    }
}