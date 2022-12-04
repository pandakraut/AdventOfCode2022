using System;
using System.IO;
using System.Collections.Generic;

namespace AdventOfCode2022
{
    class day4_1
    {
        static void Main(string[] args)
        {
            int total = 0;
            foreach (string line in File.ReadLines("../../../inputDay4.txt"))
            {
                string[] split = line.Split(',');
                string[] firstPair = split[0].Split('-');
                string[] secondPair = split[1].Split('-');

                Int64 firstStart = Convert.ToInt64(firstPair[0]);
                Int64 firstEnd = Convert.ToInt64(firstPair[1]);
                Int64 secondStart = Convert.ToInt64(secondPair[0]);
                Int64 secondEnd = Convert.ToInt64(secondPair[1]);


                if (firstStart <= secondStart && secondEnd <= firstEnd)
                {
                    total++;
                }
                else if (secondStart <= firstStart && firstEnd <= secondEnd)
                {
                    total++;
                }

            }

            Console.WriteLine("output: " + total);
        }
    }
}