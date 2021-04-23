using Assets.Scripts.Unity;
using System.Collections.Generic;

namespace All_Towers_Target_Camo
{
    class BloonModifier
    {
        Dictionary<string, bool> bloonTargetCamoDefault = new Dictionary<string, bool>();

        public BloonModifier()
        {
            var bloonModels = Game.instance.model.bloons;
            foreach (var bloonModel in bloonModels)
            {
                bloonTargetCamoDefault.Add(bloonModel.name, bloonModel.isCamo);
            }
        }

        public void RemoveCamoAll()
        {
            var bloonModels = Game.instance.model.bloons;
            foreach (var bloonModel in bloonModels)
            {
                bloonModel.isCamo = false;
            }
        }

        public void ResetCamoToDefault()
        {
            var bloonModels = Game.instance.model.bloons;
            foreach (var bloonModel in bloonModels)
            {
                bloonModel.isCamo = bloonTargetCamoDefault[bloonModel.name];
            }
        }
    }
}
