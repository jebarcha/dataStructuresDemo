using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithms.DataUtils
{
    public static class Utils
    {
        public static string Array2String<T>(IEnumerable<T> list)
        {
            return "[" + string.Join(", ", list) + "]";
        }
        public static void Print(int val)
        {
            Console.WriteLine(val);
        }
        public static void PrintString(IEnumerable<int> arr)
        {
            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }
        }
    }
}
