﻿using System;
using System.Collections.Generic;

namespace CoveringArraysChecker
{
    public static class Print
    {
        public static void Array(List<string> array)
        {
            foreach (var line in array)
            {
                Console.WriteLine(line);
            }

            Console.WriteLine();
        }

        public static void Result(bool result)
        {
            if (result)
            {
                Console.WriteLine(" YES ! The given array is a Covering array.");
            }
            else
            {
                Console.WriteLine(" NO ! The given array is not a Covering array.");
            }
        }
    }
}
