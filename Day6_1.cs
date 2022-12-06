using System;
using System.IO;
using System.Collections.Generic;

namespace AdventOfCode2022
{
    class day6_1
    {
        static void Main(string[] args)
        {
            int total = 0;
            LinkedList<char> list = new LinkedList<char>();
            List<char> uniqueList = new List<char>();
            foreach (string line in File.ReadLines("../../../inputDay6.txt"))
            {
                for (int i = 0; i < line.Length; i++)
                {
                    list.AddLast(line[i]);
                    if (list.Count == 4)
                    {
                        foreach (char u in list)
                        {
                            if (!uniqueList.Contains(u))
                            {
                                uniqueList.Add(u);
                            }
                        }
                        if (uniqueList.Count == 4)
                        {
                            total = i + 1;
                            break;
                        }
                        else
                        {
                            uniqueList.Clear();
                            list.RemoveFirst();
                        }
                    }
                }
            }

            Console.WriteLine("output: " + total);
        }
    }
}