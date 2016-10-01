using System;
using System.Collections.Generic;
using System.Text;

namespace CoveringArraysChecker
{
    public class Permutation
    {
        private int levelOfRecursion = -1;
        private int numberOfElements;
        private int[] permutationValue = new int[0];
        private List<string> allCombinations;

        private char[] inputSet;
        public char[] InputSet
        {
            get { return inputSet; }
            set { inputSet = value; }
        }

        private int permutationCount = 0;
        public int PermutationCount
        {
            get { return permutationCount; }
            set { permutationCount = value; }
        }

        public List<string> GetAllCombination(string input)
        {
            this.allCombinations = new List<string>();

            this.InputSet = this.MakeCharArray(input);
            this.CalcPermutation(0);

            return this.allCombinations;

        }
        public char[] MakeCharArray(string InputString)
        {
            char[] charString = InputString.ToCharArray();
            Array.Resize(ref permutationValue, charString.Length);
            numberOfElements = charString.Length;
            return charString;
        }

        public void CalcPermutation(int k)
        {
            // Отчита, че влизаме едно ниво по-навътре в рекурсията
            levelOfRecursion++;

            // Слага стойност elementLevel на позиция к
            permutationValue.SetValue(levelOfRecursion, k);

            // Дъното на рекурсията
            if (levelOfRecursion == numberOfElements)
            {
                // Всички размени на символи (две по две) са свършили
                OutputPermutation(permutationValue);
            }
            else
            {
                // Фиксира i-то и проверява всички възможни комбнации след него
                for (int i = 0; i < numberOfElements; i++)
                {
                    // Ако на елемента от масива не му е зададена стойност
                    if (permutationValue[i] == 0)
                    {
                        CalcPermutation(i);
                    }
                }
            }

            // Занулява масива при излизане от рекурсията
            levelOfRecursion--;
            permutationValue.SetValue(0, k);
        }

        /// <summary>
        /// Принтира резултата
        /// </summary>
        private void OutputPermutation(int[] value)
        {
            StringBuilder sb = new StringBuilder();

            foreach (int i in value)
            {
                sb.Append(inputSet.GetValue(i - 1));
            }

            this.allCombinations.Add(sb.ToString());
            PermutationCount++;
        }
    }

}
