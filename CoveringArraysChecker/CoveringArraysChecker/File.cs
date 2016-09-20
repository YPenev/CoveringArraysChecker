using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoveringArraysChecker
{
    public class File
    {
        private List<string> allCombinations;
        private int result;
        private int statesPerElement;
        private int elementsCount;
        private int t;

        public bool CheckAllLines(List<string> lines)
        {
            Permutation2 per = new Permutation2();

            allCombinations = per.GetCombinations(1); //TODO: remove magic string (statesPerElement)

            Checker checker = new Checker(lines, allCombinations);

            if (checker.CheckAllColumns(3))  //TODO: remove magic string (t)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool CheckLine(string line)
        {
            foreach (var combination in allCombinations)
            {
                if (!line.Contains(combination))
                {
                    Console.WriteLine($"In line: \n {line} \n Does not contain: \n {combination}");
                    return false;
                }
            }

            return true;
        }

        public List<string> ReadFile(string path, int result, int statesPerElement, int elementsCount, int t)
        {
            string line;
            List<string> lines = new List<string>();

            this.result = result;
            this.statesPerElement = statesPerElement;
            this.elementsCount = elementsCount;
            this.t = t;

            try
            {   // Open the text file using a stream reader.
                using (StreamReader file = new StreamReader(path))
                {
                    while ((line = file.ReadLine()) != null)
                    {
                        lines.Add(line);
                    }
                }

                return lines;
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);

                throw new Exception("The file could not be read:", e);
            }
        }
    }
}
