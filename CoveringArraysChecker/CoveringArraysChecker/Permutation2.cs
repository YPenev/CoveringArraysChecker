using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoveringArraysChecker
{
    public class Permutation2
    {
        private List<string> combinations;

        public Permutation2()
        {
            this.combinations = new List<string>();
        }

        public List<string> GetCombinations(int length)
        {
            var letters = Common.GetNumbersFromZeroToN(length);

            MakeCombinations(letters, length + 1, "");

            return combinations;
        }

        private void MakeCombinations(string letters, int length, string prefix = "")
        {
            if (length == 0)
            {
                this.combinations.Add(prefix);
                return;
            }

            for (var i = 0; i < letters.Length; i++)
            {
                var newPrefix = prefix + " " + letters[i];
                MakeCombinations(letters, length - 1, newPrefix);
            }
        }
    }
}
