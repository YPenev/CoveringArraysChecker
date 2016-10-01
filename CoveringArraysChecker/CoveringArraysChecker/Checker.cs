using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoveringArraysChecker
{
    public class Checker
    {
        private List<string> array;
        private List<string> allCombinations;
        private List<string> allColumnCombination;

        public Checker(File arrayFile)
        {
            this.array = arrayFile.array;

            // Всички комбинации от t колони
            // Трябва да не се повтарят индексите на колоните !!!
            Permutation2 per = new Permutation2();
            this.allCombinations = per.GetAllPosibleCombinations(arrayFile.statesPerElement - 1);

            // (FIXED) Грешка, трябва да намерия всички комбинации от Т елемента в Н на брой елемента
            // Може да стане като намерим всички възможни комбинации и вземем само тези който са с Т дължина и нямат повтарящи се елементи
            per = new Permutation2();
            allColumnCombination = per.GetPermutationWithoutRepeat(arrayFile.elementsCount, arrayFile.t, " ");
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
            // (FIXED) Не проверявам за всяка комбинация от колони, и не запълвам листа с комбинациите като проверя
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

                //(FIXED) Проблем търси 0000 в 00
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
                StringBuilder errorInfo = new StringBuilder();

                errorInfo.Append("In column:");

                foreach (var item in columnsIndexes)
                {
                    errorInfo.Append(item);
                }
                errorInfo.Append(Environment.NewLine);
                errorInfo.Append("Not found combinations: ");

                foreach (var item in tempAllCombinations)
                {
                    errorInfo.Append(item);
                }

                Log.WriteResult(errorInfo.ToString());
                Console.WriteLine(errorInfo.ToString());
                return false;
            }
        }
    }
}
