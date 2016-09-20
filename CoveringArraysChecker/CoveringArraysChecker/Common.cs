using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoveringArraysChecker
{
   public static class Common
    {
        public static string GetNumbersFromZeroToN(int length)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i <= length; i++)
            {
                sb.Append(i.ToString());
            }

            return sb.ToString();
        }
    }
}
