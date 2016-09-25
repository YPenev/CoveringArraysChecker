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
        private string charBetweenElements;

        public Permutation2(string charBetweenElements)
        {
            this.combinations = new List<string>();
            this.charBetweenElements = charBetweenElements;
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
                var newPrefix = prefix + this.charBetweenElements + letters[i];
                MakeCombinations(letters, length - 1, newPrefix);
            }
        }

        // Does it work ?
        public List<string> GetPermutationWithoutRepeat(int length)
        {
            var letters = Common.GetNumbersFromZeroToN(length - 1).ToCharArray();

            MakePermutationWithoutRepeat(letters, 0, length - 1);


            return combinations;
        }


        private void MakePermutationWithoutRepeat(char[] arry, int i, int n)
        {
            int j;
            if (i == n)
            {
                this.combinations.Add(new string(arry));
            }
            else
            {
                for (j = i; j <= n; j++)
                {
                    swap(ref arry[i], ref arry[j]);
                    MakePermutationWithoutRepeat(arry, i + 1, n);
                    swap(ref arry[i], ref arry[j]); //backtrack
                }
            }
        }

        private void swap(ref char a, ref char b)
        {
            char tmp;
            tmp = a;
            a = b;
            b = tmp;
        }

   
    }
}
