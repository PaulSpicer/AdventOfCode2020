using System;
using System.IO;

namespace Day_3
{
    class Program
    {
        static void Main(string[] args)
        {
            var treeData = ReadInputFileToArray();

            long multipliedTrees = 1;

            var runs = new (int  xOffset, int yOffset)[]
            {
                (1,1),
                (3,1),
                (5,1),
                (7,1),
                (1,2)
            };

            foreach (var r in runs)
            {
                int trees = 0;
                var xPosition = 0;
                for (int i = 0; i < treeData.Length; i += r.yOffset )
                {
                    if (treeData[i][xPosition] == '#')
                    {
                        trees++;
                    }
                    
                    xPosition += r.xOffset;
                    xPosition %= treeData[i].Length;
                }

                multipliedTrees *= trees;
            }
            
            Console.Write($"There are {multipliedTrees} trees.");
        }
        
        private static string[] ReadInputFileToArray()
        {
            return File.ReadAllLines("input.txt");
        }
    }
}