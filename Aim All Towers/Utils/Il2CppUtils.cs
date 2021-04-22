using UnhollowerBaseLib;

namespace Aim_All_Towers.Utils
{
    class Il2CppUtils
    {
        public static Il2CppReferenceArray<T> Add<T>(Il2CppReferenceArray<T> array, T item) where T : Il2CppObjectBase
        {
            var initialArray = array;
            array = new Il2CppReferenceArray<T>(initialArray.Length + 1);

            for (int i = 0; i < initialArray.Length; i++)
                array[i] = initialArray[i];

            array[array.Length - 1] = item;
            return array;
        }
    }
}
