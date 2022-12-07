using System;
using System.IO;
using System.Collections.Generic;
using System.Security.AccessControl;
using System.Reflection;
using System.Xml.Schema;

namespace AdventOfCode2022
{
    class day7_1
    {
        public static List<string> commands = new List<string>();
        public static Dictionary<string, Int64> dirSize = new Dictionary<string, Int64>();
        public static Dictionary<string, List<string>> dirChildren = new Dictionary<string, List<string>>();
        public static Dictionary<string, Int64> finalSize = new Dictionary<string, Int64>();
        public static Int64 total = 0;

        static void Main(string[] args)
        {
            foreach (string line in File.ReadLines("../../../inputDay7.txt"))
            {
                commands.Add(line);
            }

            string curDir = "";
            string curCom = "";
            string newDir = "";
            for (int i = 0; i < commands.Count; i++)
            {
                curCom = commands[i];
                if (curCom.StartsWith("$ cd"))
                {
                    string[] split = curCom.Split(' ');
                    if (split[2] == "..")
                    {
                        curDir = curDir.Remove(curDir.LastIndexOf("-"));
                    }
                    else if (!dirChildren.ContainsKey(split[2]))
                    {
                        if (curDir == "")
                        {
                            newDir = split[2];
                        }
                        else
                        {
                            newDir = curDir + "-" + split[2];
                        }
                        dirChildren.Add(newDir, new List<string>());
                        dirSize.Add(newDir, 0);
                        curDir = newDir;
                    }
                }
                else if (curCom.StartsWith("$ ls"))
                {
                    //do nothing
                }
                else if (curCom.StartsWith("dir"))
                {
                    string[] split = curCom.Split(' ');
                    dirChildren[curDir].Add(split[1]);
                }
                else
                {
                    string[] split = curCom.Split(' ');
                    dirSize[curDir] += Convert.ToInt64(split[0]);
                }
            }

            processChildren("/");
          
            Console.WriteLine("output: " + total);
        }

        public static Int64 processChildren(string dir)
        {
            Int64 size = dirSize[dir];
            foreach (string child in dirChildren[dir])
            {
                size += processChildren(dir + "-" + child);
            }
            if (size <= 100000)
            {
                total += size;
            }
            finalSize.Add(dir, size);
            return size;
        }
    }
}