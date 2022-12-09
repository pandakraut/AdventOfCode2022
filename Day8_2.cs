using System;
using System.IO;
using System.Collections.Generic;
using System.Security.AccessControl;
using System.Reflection;
using System.Xml.Schema;

namespace AdventOfCode2022
{
    class day8_2
    {
        public static List<List<point>> mapping = new List<List<point>>();
        public static int total = 0;
        public static int highestScore = 0;

        static void Main(string[] args)
        {
            List<point> currentLine = new List<point>();

            foreach (string line in File.ReadLines("../../../inputDay8.txt"))
            {
                currentLine = new List<point>();
                foreach (char c in line)
                {
                    int height = Convert.ToInt32(c.ToString());
                    currentLine.Add(new point(height));
                }
                mapping.Add(currentLine);
            }

            point currentPoint;

            //List<lowPoint> lowPointList = new List<lowPoint>();
            for (int row = 0; row < mapping.Count; row++)
            {
                currentLine = mapping[row];
                for (int col = 0; col < currentLine.Count; col++)
                {
                    currentPoint = currentLine[col];
                    //left 0
                    checkDirection(currentPoint, col, row, 0);
                    //right 1
                    checkDirection(currentPoint, col, row, 1);
                    //up 2
                    checkDirection(currentPoint, col, row, 2);
                    //down 3
                    checkDirection(currentPoint, col, row, 3);

                    if (currentPoint.score > highestScore)
                    {
                        highestScore = currentPoint.score;
                    }
                }
            }
            Console.WriteLine("output: " + highestScore);
        }

        public static void checkDirection(point currentPoint, int col, int row, int dir)
        {
            bool setVisible = false;
            int curDist = 0;
            int lastHeight = currentPoint.height;
            if (dir == 0)
            {
                //check left
                if (col == 0)
                {
                    setVisible = true;
                }
                else
                {
                    int inc = 1;
                    while (col - inc >= 0)
                    {
                        curDist++;
                        if (currentPoint.height > mapping[row][col - inc].height))
                        {
                            lastHeight = mapping[row][col - inc].height;
                            setVisible = true;
                        }
                        else
                        {
                            setVisible = false;
                            break;
                        }
                        inc++;
                    }
                }
            }
            else if (dir == 1)
            {
                //check right
                if (col == mapping[row].Count - 1)
                {
                    setVisible = true;
                }
                else
                {
                    int inc = 1;
                    while (col + inc <= mapping[row].Count - 1)
                    {
                        curDist++;
                        if (currentPoint.height > mapping[row][col + inc].height))
                        {
                            lastHeight = mapping[row][col + inc].height;
                            setVisible = true;
                        }
                        else
                        {
                            setVisible = false;
                            break;
                        }
                        inc++;
                    }
                }
            }
            else if (dir == 2)
            {
                //check up
                if (row == 0)
                {
                    setVisible = true;
                }
                else
                {
                    int inc = 1;
                    while (row - inc >= 0)
                    {
                        curDist++;
                        if (currentPoint.height > mapping[row - inc][col].height))
                        {
                            lastHeight = mapping[row - inc][col].height;
                            setVisible = true;
                        }
                        else
                        {
                            setVisible = false;
                            break;
                        }
                        inc++;
                    }
                }
            }
            else if (dir == 3)
            {
                //check up
                if (row == mapping.Count - 1)
                {
                    setVisible = true;
                }
                else
                {
                    int inc = 1;
                    while (row + inc <= mapping.Count - 1)
                    {
                        curDist++;
                        if (currentPoint.height > mapping[row + inc][col].height))
                        {
                            lastHeight = mapping[row + inc][col].height;
                            setVisible = true;
                        }
                        else
                        {

                            setVisible = false;
                            break;
                        }
                        inc++;
                    }
                }
            }

            currentPoint.score *= curDist;
            if (setVisible && !currentPoint.visible)
            {
                currentPoint.visible = true;
                total++;
            }
        }

        public class point
        {
            public int height { get; set; }

            public int score { get; set; }

            public bool visible { get; set; }

            public point(int inputHeight)
            {
                height = inputHeight;
                score = 1;
                visible = false;
            }
        }
    }
}