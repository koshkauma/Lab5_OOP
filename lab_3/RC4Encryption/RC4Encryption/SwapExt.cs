using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RC4Encryption
{
    public static class SwapExt
    {

       public static void Swap<T>(this T[] array, int index1, int index2)
       {
                T temp = array[index1];
                array[index1] = array[index2];
                array[index2] = temp;
       }
     }
    
}
