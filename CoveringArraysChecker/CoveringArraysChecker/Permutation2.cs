using System;
using System.Collections.Generic;
using System.Linq;

namespace CoveringArraysChecker
{
    public class Permutation2
    {
        private List<string> combinations;
        private string charBetweenElements;

        public Permutation2()
        {
            this.combinations = new List<string>();
            this.charBetweenElements = string.Empty;
        }

        public List<string> GetAllPosibleCombinations(int length)
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
        public List<string> GetPermutationWithoutRepeat(int length, int t, string charBetweenElements)
        {
            this.charBetweenElements = charBetweenElements;

            var letters = Common.GetNumbersFromZeroToN(length - 1);

            MakePermutationWithoutRepeat(letters, t);

            return combinations;
        }


        private void MakePermutationWithoutRepeat(string word, int t)
        {

            List<string> result = new List<string>();

            int total = (int)Math.Pow(2, word.Length);


            for (int i = 0; i < total; i++)
            {
                string tempWord = string.Empty;
                // pick the letters from the word

                for (int temp = i, j = 0; temp > 0; temp = temp >> 1, j++)
                {
                    if ((temp & 1) == 1)
                    {
                        tempWord += word[j];
                    }
                }

                // generate permutations from the letters
                List<string> permutations;
                Permutations(tempWord, out permutations);

                foreach (var prm in permutations)
                    result.Add(prm);
            }

            // remove duplicates
            combinations = result.Distinct().Where(x => x.Length == t).ToList();  // TODO: Тук трябва да подам Т (3)
        }

        static void Permutations(string str, out List<string> result)
        {
            result = new List<string>();

            if (str.Length == 1)
            {
                result.Add(str);
                return;
            }

            for (int i = 0; i < str.Length; i++)
            {
                char c = str[i];
                string temp = str.Remove(i, 1);

                List<string> tempResult;
                Permutations(temp, out tempResult);

                foreach (var tempRes in tempResult)
                    result.Add(c + tempRes);
            }
        }


    }
}
