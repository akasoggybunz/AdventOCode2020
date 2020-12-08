using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace Day1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" ~~~ Advent of Code Day 1!!! ~~~");
            List<string> inputList = new List<string>();

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
                Console.WriteLine("Calculating...");
                foreach (var value in inputList)
                {
                    foreach (var value2 in inputList)
                    {
                        int sum = Convert.ToInt32(value) + Convert.ToInt32(value2);
                        if ( sum == 2020)
                        {
                            Console.WriteLine("Value 1: " + value);
                            Console.WriteLine("Value 2: " + value2);
                            Console.WriteLine(Convert.ToInt32(value) * Convert.ToInt32(value2)); 
                        }
                    }
                }

            }
            catch (Exception e)
            {
                // Let the user know what went wrong.
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

            
        }
    }
}
