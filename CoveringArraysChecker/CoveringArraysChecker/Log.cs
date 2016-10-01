using System.Collections.Generic;

namespace CoveringArraysChecker
{
    public static class Log
    {
        private const string CurrentArray = "CurrentArray.txt";
        private const string CurrentResult = "CurrentResult.txt";

        public static void WriteArray(List<string> array)
        {
            System.IO.File.WriteAllLines(CurrentArray, array);
        }

        public static string ReadArray()
        {
            return System.IO.File.ReadAllText(CurrentArray);
        }
        public static void WriteResult(string content)
        {
            System.IO.File.WriteAllText(CurrentResult, content);
        }

        public static string ReadResult()
        {
            return System.IO.File.ReadAllText(CurrentResult);
        }
    }
}
