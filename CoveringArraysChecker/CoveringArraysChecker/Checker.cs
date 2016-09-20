using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoveringArraysChecker
{
    public class Checker
    {
        private List<string> array;
        private List<string> allCombinations;
        private List<string> allColumnCombination;

        public Checker(List<string> givenArray, List<string> combinations, int t)
        {
            this.array = givenArray;
            this.allCombinations = combinations;

            // Всички комбинации от t колони
            Permutation2 per = new Permutation2();
            allColumnCombination = per.GetCombinations(t);
        }

        public bool CheckAllColumns(int t)
        {

            foreach (var tColumnCombination in allColumnCombination)
            {
                // Лист от индекси на колоните който трябва да провери
                List<int> columnsIndexes = tColumnCombination.Split(' ').Select(int.Parse).ToList();

                if (!CheckTColumns(columnsIndexes))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Проверява един набор от t колони
        /// </summary>
        private bool CheckTColumns(List<int> columnsIndexes)
        {
            // За всеки ред от масива
            for (int i = 0; i < array[i].Length; i++)
            {
                var currentCombination = new StringBuilder();

                // Построява текущата комбинация
                foreach (var index in columnsIndexes)
                {
                    currentCombination.Append(array[i][index]);
                }

                // Проверява дали конкретната комбинация съществъва в колекцията със всияки комбинации който трябва да се съдържат
                // Ако я има в колекцията , я маха
                if (allCombinations.Contains(currentCombination.ToString()))
                {
                    allCombinations.Remove(currentCombination.ToString());
                    break;
                }
            }

            if (allCombinations.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
           


            //foreach (var combination in allCombinations)
            //{

            //    bool isCombinationFind = false;

            //    for (int i = 0; i < array.Count; i++)
            //    {
            //        string partOfColumn = string.Empty;

            //        if (startColumn + lenght >= array[i].Length)
            //        {
            //            partOfColumn = array[i].Substring(startColumn, array[i].Length - 1 - startColumn) + array[i].Substring(0, lenght % array[i].Length);
            //        }
            //        else
            //        {
            //            partOfColumn = array[i].Substring(startColumn, lenght);
            //        }

            //        if (partOfColumn.Contains(combination))
            //        {
            //            isCombinationFind = true;
            //            break;
            //        }
            //    }

            //    if (!isCombinationFind)
            //    {
            //        return false;
            //    }
            //}

            //return true;
        }
    }
}
