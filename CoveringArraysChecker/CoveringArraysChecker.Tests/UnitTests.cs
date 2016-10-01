using System;
using NUnit.Framework;
using CoveringArraysChecker;

namespace CoveringArraysChecker.Tests
{
    [TestFixture]
    public class UnitTests
    {
        [TestCase("NewFile.txt")]
        [TestCase("MockArray.txt")]
        public void File_Construction_MustOpenFileWhenPathIsCorrect(string FileName)
        {
            System.IO.File.WriteAllText(FileName, "test");
            File file = new File(FileName);
        }

        [TestCase("")]
        [TestCase("incorrect path")]
        [TestCase("testFile")]
        [TestCase("IncorrethPart.txt")]
        public void File_Construction_MustThrowExeptionWhenPathIsIncorrect(string path)
        {
            Assert.Throws<Exception>(() => new File("testFile.txt"));
        }

        [TestCase(3,"0123")]
        [TestCase(9, "0123456789")]
        public void Common_GetNumbersFromZeroToN_MustReturnProperlyNumbers(int number, string expectedResult)
        {
            var actualResult = Common.GetNumbersFromZeroToN(number);

            Assert.AreEqual(expectedResult,actualResult);
        }


    }
}
