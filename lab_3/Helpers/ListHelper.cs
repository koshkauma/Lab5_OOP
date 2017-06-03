using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab_3.Helpers
{
    public static class ListHelper
    {
        public static bool CheckIfUnique<T>(T someItem, List<T> listToCheck)
        {
            bool duplicateFound = false;
            int i = 0;
            while (!duplicateFound && i < listToCheck.Count)
            {
                if (listToCheck[i].GetType().ToString() == someItem.GetType().ToString())
                {
                    duplicateFound = true;
                }
                i++;
            }
            return duplicateFound;
        }

        public static bool IsAddedToList<T>(T someItem, List<T> someList)
        {

            if (!CheckIfUnique(someItem, someList))
            {
                someList.Add(someItem);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
