using AdventOfCode2020.Helper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020
{
    static public class Day3
    {
        public static void Run()
        {
            string content = FileHelper.ReadResourceFile("AdventOfCode2020.Resources.Day3Input.txt").Result;
            List<string> rows = content.Split("\r\n").ToList();

            Console.WriteLine(CountTrees(rows, 1, 1));
            Console.WriteLine(CountTrees(rows, 3, 1));
            Console.WriteLine(CountTrees(rows, 5, 1));
            Console.WriteLine(CountTrees(rows, 7, 1));
            Console.WriteLine(CountTrees(rows, 1, 2));

            Console.WriteLine(CountTrees(rows, 3, 1) * CountTrees(rows, 1, 1) * CountTrees(rows, 5, 1) * CountTrees(rows, 7, 1) * CountTrees(rows, 1, 2));           
        }

        private static long CountTrees(List<string> rows, int rightSteps, int downSteps)
        {
            long treeCount = 0;
            int index = 0;
            for (int i = 0; i < rows.Count; i = i + downSteps)
            {
                if (rows[i][index] == '#')
                {
                    treeCount++;
                }

                index = index + rightSteps;

                if (index >= rows[i].Length)
                {
                    index = index - rows[i].Length;
                }
            }

            return treeCount;
        }
    }
}
