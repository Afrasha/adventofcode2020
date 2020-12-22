using AdventOfCode2020.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020
{
    static public class Day2
    {
        public static void Run()
        {
            string content = FileHelper.ReadResourceFile("AdventOfCode2020.Resources.Day2Input.txt").Result;
            List<string> passwords = content.Split("\r\n").ToList();
            Console.WriteLine(ValidatePasswords(passwords));
            Console.WriteLine(ValidatePasswords2(passwords));
        }

        private static int ValidatePasswords(List<string> passwords)
        {
            int validCount = 0;

            foreach (var password in passwords)
            {
                var passwordContent = password.Split(": ");
                string ruleContent = passwordContent[0];
                string passwordValue = passwordContent[1];

                var range = ruleContent.Split(' ')[0].Split('-');
                int min = int.Parse(range[0]);
                int max = int.Parse(range[1]);

                char requiredChar = ruleContent.Split(' ')[1].ToCharArray()[0];

                int count = passwordValue.Count(x => x == requiredChar);

                if (count >= min & count <= max)
                {
                    validCount++;
                }
            }

            return validCount;
        }

        private static int ValidatePasswords2(List<string> passwords)
        {
            int validCount = 0;

            foreach (var password in passwords)
            {
                var passwordContent = password.Split(": ");
                string ruleContent = passwordContent[0];
                string passwordValue = passwordContent[1];

                var range = ruleContent.Split(' ')[0].Split('-');
                int position1 = int.Parse(range[0]) - 1;
                int position2 = int.Parse(range[1]) - 1;

                if (position1 < 0 || position2 < 0 || position1 >= passwordValue.Length || position2 >= passwordValue.Length)
                {
                    continue;
                }

                char requiredChar = ruleContent.Split(' ')[1].ToCharArray()[0];
                bool firstMatch = passwordValue[position1] == requiredChar;
                bool secondMatch = passwordValue[position2] == requiredChar;

                if (firstMatch && !secondMatch || !firstMatch && secondMatch)
                {
                    validCount++;
                }
            }

            return validCount;
        }
    }
}
