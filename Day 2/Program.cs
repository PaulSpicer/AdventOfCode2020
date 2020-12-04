using System;
using System.Collections.Generic;
using System.IO;

namespace Day_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var rawPasswords = ReadInputFileToArray();
            int noOfValidPasswords = 0, noOfValidPasswords2 = 0;
            
            for (int i = 0; i < rawPasswords.Length; i++)
            {
                var pw = new PasswordData(rawPasswords[i]);
                if (pw.IsPasswordValid())
                    noOfValidPasswords++;

                if (pw.IsPasswordValid2())
                    noOfValidPasswords2++;
            }
            
            Console.WriteLine($"There are {noOfValidPasswords} valid passwords for part 1");
            Console.WriteLine($"There are {noOfValidPasswords2} valid passwords for part 2");
        }
        
        private static string[] ReadInputFileToArray()
        {
            return File.ReadAllLines("input.txt");
        }
    }

    class PasswordData
    {
        private int Minimum { get; set; }
        private int Maximum { get; set; }
        private char Letter { get; set; }
        private string Password { get; set; }

        public PasswordData (string rawInput)
        {
            var dashIndex = rawInput.IndexOf('-');
            var colonIndex = rawInput.IndexOf(':');

            Minimum = int.Parse(rawInput.Substring(0, dashIndex));
            Maximum = int.Parse(rawInput.Substring(dashIndex + 1,  colonIndex - dashIndex - 3));
            Letter = char.Parse(rawInput.Substring(colonIndex - 1, 1));
            Password = rawInput.Substring(colonIndex + 2, rawInput.Length - colonIndex - 2);
        }

        public bool IsPasswordValid()
        {
            var count = 0;
            foreach (char c in Password)
            {
                if (c == Letter)
                {
                    count++;
                }
            }
            return count >= Minimum && count <= Maximum;
        }
        public bool IsPasswordValid2()
        {
            return (Password[Minimum - 1] == Letter || Password[Maximum - 1] == Letter) && Password[Minimum - 1] != Password[Maximum - 1];
        }
    }
}