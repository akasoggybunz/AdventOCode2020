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
                long totalTreesHit = 0;

                using StreamReader sr = new StreamReader("./input.txt");
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                    inputList.Add(line);
                }
                // This while and foreach could be together.. but bollocks 
                Console.WriteLine("Calculating Route...");
                totalTreesHit = TreesHitWithSlope(inputList, 3, 1);
                Console.WriteLine("Trees hit Part 1: " + totalTreesHit);
                Console.WriteLine("~~~~~~~~Calculate all Slopes~~~~~~~");
                totalTreesHit = 0;

                totalTreesHit =  TreesHitWithSlope(inputList, 3, 1) *
                                 TreesHitWithSlope(inputList, 1, 1) *
                                 TreesHitWithSlope(inputList, 5, 1) *
                                 TreesHitWithSlope(inputList, 7, 1) *
                                 TreesHitWithSlope(inputList, 1, 2);

                Console.WriteLine("Trees hit Part 2: " + totalTreesHit);
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
        /// <param name="run">slope right</param>
        /// <param name="rise">slope down</param>
        /// <returns>Tree Hit Count</returns>
        public static int TreesHitWithSlope(List<string> routeList, int run, int rise)
        {
            int treesHit = 0;
            int rightPos = 0;
            Console.Write(routeList[0].ToString() + "        ");

            for (int i = 0; i < routeList.Count; i += rise)
            {

                if (i + rise >= routeList.Count)
                {
                    break;
                }
                var routeRise = routeList[i + rise].ToCharArray();
                var routeRun =  routeList[i].ToCharArray();
                // check Position
                rightPos = (rightPos + run < routeRise.Length) ? rightPos + run : ((rightPos + run)% routeRise.Length) ; 
                // check tree hit
                if (routeRise[rightPos].Equals('#'))
                {
                    treesHit++;
                    routeRise[rightPos] = 'X';
                }
                else
                {
                    routeRise[rightPos] = 'O';

                }

                //foreach (var r in routeRise.ToList()) Console.Write(r);
                //Console.WriteLine("              Pos: " + rightPos + "," +i + "   TreesHit: " + treesHit);
            }
            
            Console.WriteLine("Rise: " + rise + " run: " + run + " treesHit: "+   treesHit);
            return treesHit;
        }

    }
}
