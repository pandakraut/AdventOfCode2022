using System;
using System.IO;
using System.Collections.Generic;
using System.Security.AccessControl;
using System.Reflection;
using System.Xml.Schema;

namespace AdventOfCode2022
{
    class day8_1
    {
        public static List<List<point>> mapping = new List<List<point>>();
        public static int total = 0;

        static void Main(string[] args)
        {
            List<point> currentLine = new List<point>();

            foreach (string line in File.ReadLines("../../../InputDay8.txt"))
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
                }
            }
            Console.WriteLine("output: " + total);
        }

        public static void checkDirection(point currentPoint, int col, int row, int dir)
        {
            bool setVisible = false;
            if (dir == 0)
            {
                currentPoint.leftChecked = true;
                //check left
                if (col == 0)
                {
                    setVisible = true;
                    currentPoint.leftVisible = true;
                }
                else
                {
                    int inc = 1;
                    while (col - inc >= 0)
                    {
                        if (currentPoint.height > mapping[row][col - inc].height)
                        {
                            setVisible = true;
                            currentPoint.leftVisible = true;
                        }
                        else
                        {
                            setVisible = false;
                            currentPoint.leftVisible = false;
                            break;
                        }
                        inc++;
                    }
                }
            }
            else if (dir == 1)
            {
                currentPoint.rightChecked = true;
                //check right
                if (col == mapping[row].Count - 1)
                {
                    setVisible = true;
                    currentPoint.rightVisible = true;
                }
                else
                {
                    int inc = 1;
                    while (col + inc <= mapping[row].Count - 1)
                    {
                        if (currentPoint.height > mapping[row][col + inc].height)
                        {
                            setVisible = true;
                            currentPoint.rightVisible = true;
                        }
                        else
                        {
                            setVisible = false;
                            currentPoint.rightVisible = false;
                            break;
                        }
                        inc++;
                    }
                }
            }
            else if (dir == 2)
            {
                currentPoint.upChecked = true;
                //check up
                if (row == 0)
                {
                    setVisible = true;
                    currentPoint.upVisible = true;
                }
                else
                {
                    int inc = 1;
                    while (row - inc >= 0)
                    {
                        if (currentPoint.height > mapping[row - inc][col].height)
                        {
                            setVisible = true;
                            currentPoint.upVisible = true;
                        }
                        else
                        {
                            setVisible = false;
                            currentPoint.upVisible = false;
                            break;
                        }
                        inc++;
                    }
                }
            }
            else if (dir == 3)
            {
                currentPoint.downChecked = true;
                //check up
                if (row == mapping.Count - 1)
                {
                    setVisible = true;
                    currentPoint.downVisible = true;
                }
                else
                {
                    int inc = 1;
                    while (row + inc <= mapping.Count - 1)
                    {
                        if (currentPoint.height > mapping[row + inc][col].height)
                        {
                            setVisible = true;
                            currentPoint.downVisible = true;
                        }
                        else
                        {
                            setVisible = false;
                            currentPoint.downVisible = false;
                            break;
                        }
                        inc++;
                    }
                }
            }

            if (setVisible && !currentPoint.visible)
            {
                currentPoint.visible = true;
                total++;
            }
        }
        public class point
        {
            public int height { get; set; }
            public bool leftVisible { get; set; }
            public bool rightVisible { get; set; }
            public bool upVisible { get; set; }
            public bool downVisible { get; set; }
            public bool leftChecked { get; set; }
            public bool rightChecked { get; set; }
            public bool upChecked { get; set; }
            public bool downChecked { get; set; }
            public bool visible { get; set; }

            public point(int inputHeight)
            {
                height = inputHeight;
                leftVisible = false;
                rightVisible = false;
                upVisible = false;
                downVisible = false;
                leftChecked = false;
                rightChecked = false;
                upChecked = false;
                downChecked = false;
                visible = false;
            }
        }
    }
}