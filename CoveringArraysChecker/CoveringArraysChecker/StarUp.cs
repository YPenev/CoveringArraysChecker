namespace CoveringArraysChecker
{
    class StarUp
    {
        static void Main(string[] args)
        {
            // Set path
            string filePath = "testFile.txt";
            
            // Read file
            File file = new File(filePath);

            // Check array
            Checker checker = new Checker(file);
            var result = checker.CheckAllColumns();

            // Print result
            Print.Result(result);
        }
    }
}


