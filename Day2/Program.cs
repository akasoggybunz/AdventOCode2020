using System;
using System.Collections.Generic;
using System.IO;

namespace Day2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" ~~~ Advent of Code Day 1!!! ~~~");
            List<string> inputList = new List<string>();
            int sum = 0;

            // Grab Input
            try
            {
                Console.WriteLine(" ~~~ Reading Expense report input file");

                using StreamReader sr = new StreamReader("./input.txt");
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                    inputList.Add(line);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine("Error: " + exception.ToString());
            }
        }
    }
}
