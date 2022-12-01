using System;
using System.IO;
using System.Collections.Generic;

namespace AdventOfCode2022
{
    class day1_2
    {
        static void Main(string[] args)
        {
            Int64 curCal = 0;
            List<Int64> maxCal = new List<Int64>();
            foreach (string line in File.ReadLines("../../../inputDay1.txt"))
            {

                if (line.Trim().Length == 0)
                {
                    maxCal.Add(curCal);                    
                    curCal = 0;
                }
                else
                {
                    curCal += Convert.ToInt64(line);
                }
            }
            maxCal.Add(curCal);

            maxCal.Sort();
            Int64 total = maxCal[maxCal.Count - 1] + maxCal[maxCal.Count - 2] + maxCal[maxCal.Count - 3];
            Console.WriteLine("output: " + total);
        }
    }
}