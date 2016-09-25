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

        public Checker(List<string> givenArray, List<string> combinations, int n)
        {
            this.array = givenArray;
            this.allCombinations = combinations;

            // Всички комбинации от t колони
            // Трябва да не се повтарят индексите на колоните !!!
            Permutation2 per = new Permutation2(" ");

            //TODO: Грешка трябва да намерия всички комбинации от Т елемента в Н на брой елемента
            // Може да стане като намерим всички възможни комбинации и вземем само тези който са с Т дължина и нямат повтарящи се елементи
            allColumnCombination = per.GetPermutationWithoutRepeat(n);
        }

        public bool CheckAllColumns()
        {

            foreach (var tColumnCombination in allColumnCombination)
            {
                // Лист от индекси на колоните който трябва да провери

                // List<int> columnsIndexes = tColumnCombination.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

                List<int> columnsIndexes = Array.ConvertAll(tColumnCombination.ToCharArray(), c => (int)Char.GetNumericValue(c)).ToList();

                if (!CheckTColumns(columnsIndexes))
                {
                    return false;
                }
            }

            return true;
            //TODO: Не проверявам за всяка комбинация от колони, и не запълвам листа с комбинациите като проверя
        }

        /// <summary>
        /// Проверява един набор от t колони
        /// </summary>
        private bool CheckTColumns(List<int> columnsIndexes)
        {
            var tempAllCombinations = new List<string>(allCombinations);
            var currentCombination = new StringBuilder();

            // За всеки ред от масива
            for (int i = 0; i < array.Count; i++)
            {
                currentCombination.Clear();

                // Построява текущата комбинация
                foreach (var index in columnsIndexes)
                {
                    currentCombination.Append(array[i][index]);
                }

                // Проверява дали конкретната комбинация съществъва в колекцията със всияки комбинации който трябва да се съдържат
                // Ако я има в колекцията , я маха


                // Проблем търси 0000 в 00
                //   if (allCombinations.Contains(currentCombination.ToString()))

                while (tempAllCombinations.FirstOrDefault(x => currentCombination.ToString().Contains(x)) != null)
                {
                    //TODO: Може да не работи защото махаме само по една комбинация на ред
                    tempAllCombinations.Remove(tempAllCombinations.FirstOrDefault(x => currentCombination.ToString().Contains(x)));

                }
            }

            if (tempAllCombinations.Count == 0)
            {
                return true;
            }
            else
            {
                Console.WriteLine("In column:");

                foreach (var item in columnsIndexes)
                {
                    Console.Write(item);
                }
                Console.WriteLine();
                Console.WriteLine("Not found: ");
                foreach (var item in tempAllCombinations)
                {
                    Console.WriteLine(item);
                }

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
