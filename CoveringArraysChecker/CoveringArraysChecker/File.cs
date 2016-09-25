using System;
using System.Collections.Generic;
using System.IO;

namespace CoveringArraysChecker
{
    public class File
    {
        // TODO: make encapsulation
        public List<string> array;
        public List<string> allCombinations;
        public int result;
        public int statesPerElement;
        public int elementsCount;
        public int t;

        public File(string filePath)
        {
            this.ReadFile(filePath, 11, 2, 5, 3);
        }

        // TODO: Remove
        protected bool CheckAllLines(File arrayFile)
        {
            Permutation2 per = new Permutation2();

            allCombinations = per.GetAllPosibleCombinations(statesPerElement - 1);

            //Checker checker = new Checker(arrayFile.array, arrayFile.allCombinations, arrayFile.elementsCount, arrayFile.t); //TODO: remove magic string (t)

            //if (checker.CheckAllColumns())
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}

            return false;
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


        // TODO: make it private
        public void ReadFile(string path, int result, int statesPerElement, int elementsCount, int t)
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

                Print.Array(lines);
                this.array = lines;
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
