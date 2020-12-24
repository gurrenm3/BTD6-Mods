using System;

namespace Change_Cash_From_Bloon_Pops
{
    internal class Guard
    {
        public static void ThrowIfArgumentIsNull(object obj, string argumentName, string message = "")
        {
            if (obj != null)
                return;

            if (string.IsNullOrEmpty(message))
                throw new ArgumentNullException(argumentName);
            else
                throw new ArgumentNullException(argumentName, message);
        }


        public static void ThrowIfStringIsNull(string stringToCheck, string message)
        {
            if (String.IsNullOrEmpty(stringToCheck))
            {
                throw new Exception(message);
            }
        }
    }
}
