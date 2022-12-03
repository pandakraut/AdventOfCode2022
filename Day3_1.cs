using System;
using System.IO;
using System.Collections.Generic;

namespace AdventOfCode2022
{
    class day3_1
    {
        static void Main(string[] args)
        {
            int sumPriority = 0;
            HashSet<int> firstComp = new HashSet<int>();
            HashSet<int> secondComp = new HashSet<int>();
            int curFirstComp = 0;
            int curSecondComp = 0;
            char firstChar;
            char secondChar;
            foreach (string line in File.ReadLines("../../../inputDay3.txt"))
            {
                firstComp.Clear();
                secondComp.Clear();
                for (int i = 0; i < line.Length / 2; i++)
                {
                    firstChar = line[i];
                    secondChar = line[i + (line.Length / 2)];
                    curFirstComp = GetPriority((int)firstChar);
                    curSecondComp = GetPriority((int)secondChar);
                    if (curFirstComp == curSecondComp)
                    {
                        sumPriority += curFirstComp;
                        break;
                    }
                    if (!firstComp.Contains(curFirstComp))
                    {
                        firstComp.Add(curFirstComp);
                    }
                    if (!secondComp.Contains(curSecondComp))
                    {
                        secondComp.Add(curSecondComp);
                    }

                    if (secondComp.Contains(curFirstComp))
                    {
                        sumPriority += curFirstComp;
                        break;
                    }
                    if (firstComp.Contains(curSecondComp))
                    {
                        sumPriority += curSecondComp;
                        break;
                    }
                }

            }

            Console.WriteLine("output: " + sumPriority);
        }

        public static int GetPriority(int val)
        {
            if (val > 96)
            {
                return val - 96;
            }
            else
            {
                return val - 38;
            }
        }
    }
}