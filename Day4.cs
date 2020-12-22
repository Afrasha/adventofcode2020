using AdventOfCode2020.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2020
{
    static public class Day4
    {
        private static List<string> required = new List<string>
        {
            "byr:",
            "iyr:",
            "eyr:",
            "hgt:",
            "hcl:",
            "ecl:",
            "pid:",
        };

        private static List<string> eyeColor = new List<string>
        {
           "amb", "blu", "brn", "gry", "grn", "hzl" ,"oth"
        };

        public static void Run()
        {
            string content = FileHelper.ReadResourceFile("AdventOfCode2020.Resources.Day4Input.txt").Result;
            List<string> inputs = content.Replace("\r\n", " ").Split("  ").ToList();

            Console.WriteLine(CountValidPassport(inputs));
        }

        private static int CountValidPassport(List<string> inputs)
        {
            int vadlidCount = 0;

            foreach (string input in inputs)
            {
                bool valid = true;
                IEnumerable<string> entries = input.Split(" ");
                foreach (string requiredField in required)
                {
                    if (!input.Contains(requiredField))
                    {
                        valid = false;
                        break;
                    }                                     
                }

                if (valid && validEntry(entries))
                {
                    vadlidCount++;
                    Console.WriteLine(input);
                }
            }

            return vadlidCount;
        }

        private static bool validEntry(IEnumerable<string> entries)
        {
            foreach (string entry in entries)
            {
                string[] parts = entry.Split(":");

                if (parts.Length != 2)
                {
                    return false;
                }

                string key = entry.Split(":")[0];
                string value = entry.Split(":")[1];

                switch (key)
                {
                    case "byr":
                        int birthYear = int.Parse(value);
                        if (value.Length != 4 || birthYear < 1920 || birthYear > 2002)
                        {
                            return false;
                        }                      
                        break;
                    case "iyr":
                        int issueYear = int.Parse(value);
                        if (value.Length != 4 || issueYear < 2010 || issueYear > 2020)
                        {
                            return false;
                        }
                        break;
                    case "eyr":
                        int expireYear = int.Parse(value);
                        if (value.Length != 4 || expireYear < 2020 || expireYear > 2030)
                        {
                            return false;
                        }
                        break;
                    case "hgt":
                        if (value.EndsWith("cm"))
                        {
                            int height = int.Parse(value.Replace("cm", ""));
                            if (height < 150 || height > 193)
                            {
                                return false;
                            }
                        }
                        else if (value.EndsWith("in"))
                        {
                            int height = int.Parse(value.Replace("in", ""));
                            if (height < 59 || height > 76)
                            {
                                return false;
                            }
                        }
                        else
                        {
                            return false;
                        }
                        break;
                    case "hcl":
                        if (!Regex.IsMatch(value, "#[0-9a-f]{6}"))
                        {
                            return false;
                        }                       
                        break;
                    case "ecl":
                        if (!eyeColor.Contains(value))
                        {
                            return false;
                        }
                        break;
                    case "pid":
                        if (!Regex.IsMatch(value, "^\\d{9}$"))
                        {
                            return false;
                        }
                        break;
                    case "cid":
                        break;
                    default:
                        break;
                }
            }

            return true;
        }
    }
}
