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

        private void ReadFile(string path, int result, int statesPerElement, int elementsCount, int t)
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

                Log.WriteArray(lines);
                Print.Array(lines);
                this.array = lines;
            }
            catch (Exception e)
            {
                // TODO: Log exeption

                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);

                throw new Exception("The file could not be read:", e);
            }
        }
    }
}
