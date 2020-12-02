using System;
using System.IO;
using System.Net;

namespace Day_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputs = GetInputsAsIntArray();

            for (var i = 0; i < inputs.Length - 2; i++)
            {
                for (var j = i + 1; j < inputs.Length - 1; j++)
                {
                    for (var k = j + 1; k < inputs.Length; k++)
                    {
                        if (inputs[i] + inputs[j] + inputs[k] != 2020) continue;
                        var solution = inputs[i] * inputs[j] * inputs[k];
                        Console.WriteLine($"{inputs[i]}, {inputs[j]} and {inputs[k]} are the 3 values that sum to 2020. The answers is {solution}.");
                    }
                }
            }
        }

        private static int[] GetInputsAsIntArray()
        {
            var inputArray = File.ReadAllLines("input.txt");
            return Array.ConvertAll(inputArray,int.Parse);
        }
    }
}