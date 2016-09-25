using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoveringArraysChecker
{
    public static class Print
    {
        // TODO: Да се изкара от този клас (loose coupling !!!)
        public static void Array(List<string> array)
        {
            foreach (var line in array)
            {
                Console.WriteLine(line);
            }

            Console.WriteLine();
        }

        public static void Result(bool result)
        {
            if (result)
            {
                Console.WriteLine(" YES ! The given array is a Covering array.");
            }
            else
            {
                Console.WriteLine(" NO ! The given array is not a Covering array.");
            }
        }
    }
}
