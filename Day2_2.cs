using System;
using System.IO;
using System.Collections.Generic;

namespace AdventOfCode2022
{
    class day2_2
    {
        static void Main(string[] args)
        {

            int totalScore = 0;
            Dictionary<char, int> scoreMap = new Dictionary<char, int>();            
            scoreMap.Add('X', 0);
            scoreMap.Add('Y', 3);
            scoreMap.Add('Z', 6);

            Dictionary<string, int> winMap = new Dictionary<string, int>();
            winMap.Add("A X", 3);
            winMap.Add("A Y", 1);
            winMap.Add("A Z", 2);
            winMap.Add("B X", 1);
            winMap.Add("B Y", 2);
            winMap.Add("B Z", 3);
            winMap.Add("C X", 2);
            winMap.Add("C Y", 3);
            winMap.Add("C Z", 1);

            foreach (string line in File.ReadLines("../../../inputDay2.txt"))
            {
                totalScore += scoreMap[line[2]] + winMap[line];
            }

            Console.WriteLine("output: " + totalScore);
        }
    }
}