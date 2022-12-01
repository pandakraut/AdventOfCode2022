using System;
using System.IO;
using System.Collections.Generic;

namespace AdventOfCode2022
{
    class day1_1
    {
        static void Main(string[] args)
        {

            int maxCal = 0;
            int curCal = 0;
            foreach (string line in File.ReadLines("../../../inputDay1.txt"))
            {

                if (line.Trim().Length == 0)
                {
                    if (curCal >= maxCal)
                    {
                        maxCal = curCal;
                    }
                    curCal = 0;
                }
                else
                {
                    curCal += Convert.ToInt32(line);
                }
            }

            Console.WriteLine("output: " + maxCal);
        }
    }
}