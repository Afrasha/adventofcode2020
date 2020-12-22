using AdventOfCode2020.Helper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020
{
    static public class Day1
    {
        public static void Run()
        {
            string content = FileHelper.ReadResourceFile("AdventOfCode2020.Resources.Day1Input.txt").Result;
            List<int> numbers = content.Split("\r\n").Select(int.Parse).ToList();

            Console.WriteLine(Get2Numbers(numbers));
            Console.WriteLine(Get3Numbers(numbers));
        }

        

        static int Get2Numbers(List<int> numbers)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                for (int j = i; j < numbers.Count; j++)
                {
                    if (numbers[i] + numbers[j] == 2020)
                    {
                        return numbers[i] * numbers[j];
                    }
                }
            }

            return 0;
        }

        static int Get3Numbers(List<int> numbers)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                for (int j = i; j < numbers.Count; j++)
                {
                    if (numbers[i] + numbers[j] < 2020)
                    {
                        for (int k = j; k < numbers.Count; k++)
                        {
                            if (numbers[i] + numbers[j] + numbers[k] == 2020)
                                return numbers[i] * numbers[j] * numbers[k];
                        }
                    }
                }
            }

            return 0;
        }
    }
}
