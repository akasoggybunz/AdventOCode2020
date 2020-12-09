using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" ~~~ Advent of Code Day 3!!! ~~~");
            List<string> inputList = new List<string>();

            // Grab Input
            try
            {
                Console.WriteLine(" ~~~ Reading input file");

                using StreamReader sr = new StreamReader("./input.txt");
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                    inputList.Add(line);
                }
                // This while and foreach could be together.. but bollocks 
                Console.WriteLine("Calculating Route...");
                Console.WriteLine("Trees hit Part 1: " + TreesHitWithSlope(inputList, 3, 1));
                //Console.WriteLine("Valid Passwords Count Part 2: " + ValidPasswordsCount(inputList, 2).ToString());

            }
            catch (Exception exception)
            {
                Console.WriteLine("Error: " + exception.ToString());
            }
        }

        /// <summary>
        /// Get route from slope
        /// </summary>
        /// <param name="routeList">route</param>
        /// <param name="right">slope right</param>
        /// <param name="down">slope down</param>
        /// <returns>Tree Hit Count</returns>
        public static int TreesHitWithSlope(List<string> routeList, int rise, int run)
        {
            int treesHit = 0;
            int rightPos = 0;
            Console.Write(routeList[0].ToString() + "        ");

            for (int i = 1; i < routeList.Count; i++)
            {
                Console.WriteLine(i);

                var routeRise = routeList[i - 1].ToCharArray();
                var routeRun =  routeList[i].ToCharArray();
                // check Position
                rightPos = (rightPos + rise < routeRise.Length) ? rightPos + rise : ((rightPos + rise)% routeRise.Length) ; 
                // check tree hit
                if (routeRun[rightPos].Equals('#'))
                {
                    treesHit++;
                    routeRun[rightPos] = 'X';
                }
                else
                {
                    routeRun[rightPos] = 'O';

                }

                foreach (var r in routeRun.ToList()) Console.Write(r);
                Console.WriteLine("              Pos: " + rightPos);
            }
            
            return treesHit;
        }

    }
}
