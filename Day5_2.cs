using System;
using System.IO;
using System.Collections.Generic;

namespace AdventOfCode2022
{
    class day5_2
    {
        static void Main(string[] args)
        {            
            List<LinkedList<char>> linkedList = new List<LinkedList<char>>();
            foreach (string line in File.ReadLines("../../../inputDay5.txt"))
            {
                int index = 0;
                int column = 0;
                if (linkedList.Count == 0)
                {
                    for (int i = 0; i < (line.Length / 4) + 1; i++) 
                    {
                        linkedList.Add(new LinkedList<char>());
                    }
                }

                if (line.Length == 0 || line[1] == '1')
                {
                    //do nothing
                }
                else if (line[0] == 'm')
                {
                    //process steps
                    string[] commands = line.Split(' ');
                    int toMove = Convert.ToInt32(commands[1]) - 1;
                    int from = Convert.ToInt32(commands[3]) - 1;
                    int to = Convert.ToInt32(commands[5])-1;
                    while (toMove >= 0)
                    {
                        char temp = linkedList[from].ElementAt(toMove);
                        linkedList[from].Remove(linkedList[from].ElementAt(toMove));
                        linkedList[to].AddFirst(temp);                      
                        toMove--;
                    }                                    
                }
                else
                { 
                    while (index < line.Length)
                    {
                        if ((int)line[index] > 64 && (int)line[index] < 91)
                        {
                            linkedList[column].AddLast(line[index]);
                        }
                        index++;
                        if (index % 4 == 0)
                        {
                            column++;
                        }
                    }
                }
            }
        
            foreach (var s in linkedList)
            {
                Console.Write(s.First.Value);
            }
            
        }        
    }
}