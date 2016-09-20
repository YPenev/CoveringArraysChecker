using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoveringArraysChecker
{
    class Program
    {
        static void Main(string[] args)
        {

            File file = new File();

            if (file.CheckAllLines(file.ReadFile("testFile.txt",11,2,5,3)))
            {
                Console.WriteLine("True");
            }
            else
            {
                Console.WriteLine("False");
            }
        }
    }
}


