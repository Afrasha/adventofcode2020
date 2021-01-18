using AdventOfCode2020.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2020
{
    static public class Day5
    {

        public static void Run()
        {
            string content = FileHelper.ReadResourceFile("AdventOfCode2020.Resources.Day5Input.txt").Result;
            List<string> passes = content.Split("\r\n").ToList();
            // List<string> passes = new List<string> { "FBFBBFFRLR" };
            Console.WriteLine(FindHighestSeatId(passes));
        }

        private static int FindHighestSeatId(List<string> passes)
        {
            int lowestSeatId = int.MaxValue;
            int actualTotal = 0;           

            foreach (string pass in passes)
            {
                int curreltRowLow = 0;
                int curreltRowHigh = 127;
                int curreltColumnLow = 0;
                int curreltColumnHigh = 7;
                foreach (char character in pass)
                {
                    int rowMiddle = (curreltRowHigh - curreltRowLow) / 2 + 1;
                    int columnMiddle = (curreltColumnHigh - curreltColumnLow) / 2 + 1;
                    if (character == 'F') { curreltRowHigh = curreltRowHigh - rowMiddle; }
                    else if (character == 'B') { curreltRowLow = curreltRowLow + rowMiddle; }
                    else if (character == 'L') { curreltColumnHigh = curreltColumnHigh - columnMiddle; }
                    else if (character == 'R') { curreltColumnLow = curreltColumnLow + columnMiddle; }
                }

                int seatId = curreltRowHigh * 8 + curreltColumnHigh;

                actualTotal = actualTotal + seatId;

                if (seatId < lowestSeatId)
                {
                    lowestSeatId = seatId;
                }
            }

            int expectedTotal = 0;
            int currentSeatId = lowestSeatId;

            for (int i = 0; i < passes.Count() + 1; i++)
            {
                expectedTotal = expectedTotal + currentSeatId;
                currentSeatId++;
            }

            return expectedTotal - actualTotal;
        }
    }
}
