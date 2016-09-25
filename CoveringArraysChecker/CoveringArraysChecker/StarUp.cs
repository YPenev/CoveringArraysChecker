using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoveringArraysChecker
{
    class StarUp
    {
        static void Main(string[] args)
        {

            // Open file
            // Check array

            File file = new File();

            string filePath = "testFile.txt";
            var arrayFromFile = file.ReadFile(filePath, 11, 2, 5, 3);


            var result = file.CheckAllLines(arrayFromFile);

            // Print result
            Print.Result(result);
        }
    }
}


