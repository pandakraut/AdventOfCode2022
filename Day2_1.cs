using System;
using System.IO;
using System.Collections.Generic;

namespace AdventOfCode2022
{
    class day2_1
    {
        static void Main(string[] args)
        {

            int totalScore = 0;
            Dictionary<char, int> scoreMap = new Dictionary<char, int>();
            scoreMap.Add('A', 1);
            scoreMap.Add('B', 2);
            scoreMap.Add('C', 3);
            scoreMap.Add('X', 1);
            scoreMap.Add('Y', 2);
            scoreMap.Add('Z', 3);

            Dictionary<string, int> winMap = new Dictionary<string, int>();
            winMap.Add("A X", 3);
            winMap.Add("A Y", 6);
            winMap.Add("A Z", 0);
            winMap.Add("B X", 0);
            winMap.Add("B Y", 3);
            winMap.Add("B Z", 6);
            winMap.Add("C X", 6);
            winMap.Add("C Y", 0);
            winMap.Add("C Z", 3);

            foreach (string line in File.ReadLines("../../../inputDay2.txt"))
            {
                totalScore += scoreMap[line[2]] + winMap[line];
            }

            Console.WriteLine("output: " + totalScore);
        }
    }
}