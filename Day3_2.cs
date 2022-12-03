using System;
using System.IO;
using System.Collections.Generic;

namespace AdventOfCode2022
{
    class day3_2
    {
        public static HashSet<int> firstItems = new HashSet<int>();
        public static HashSet<int> secondItems = new HashSet<int>();
        static void Main(string[] args)
        {
            int sumPriority = 0;            
            
            int curFirstComp = 0;
            int curSecondComp = 0;
            char firstChar;
            char secondChar;
            int group = 1;
            foreach (string line in File.ReadLines("../../../inputDay3.txt"))
            {
                if (group > 3)
                {
                    firstItems.Clear();
                    secondItems.Clear();
                    group = 1;
                }
                for (int i = 0; i < line.Length / 2; i++)
                {
                    firstChar = line[i];
                    secondChar = line[i + (line.Length / 2)];
                    curFirstComp = GetPriority((int)firstChar);
                    curSecondComp = GetPriority((int)secondChar);
                    AddItem(curFirstComp, curSecondComp, group);                    

                    if (group == 3)
                    { 
                        if (firstItems.Contains(curFirstComp) && secondItems.Contains(curFirstComp))
                        {
                            sumPriority += curFirstComp;
                            break;
                        }
                        if (firstItems.Contains(curSecondComp) && secondItems.Contains(curSecondComp))
                        {
                            sumPriority += curSecondComp;
                            break;
                        }
                    }                    
                }
                group++;
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

        public static void AddItem(int firstVal, int secondVal, int group)
        {
            if (group == 1)
            { 
                if (!firstItems.Contains(firstVal))
                {
                    firstItems.Add(firstVal);
                }
                if (!firstItems.Contains(secondVal))
                {
                    firstItems.Add(secondVal);
                }
            }
            else if (group == 2)
            {
                if (!secondItems.Contains(firstVal))
                {
                    secondItems.Add(firstVal);
                }
                if (!secondItems.Contains(secondVal))
                {
                    secondItems.Add(secondVal);
                }
            }
        }
    }
}