using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;

namespace Day2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" ~~~ Advent of Code Day 2!!! ~~~");
            List<string> inputList = new List<string>();
            int sum = 0;

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
                Console.WriteLine("Calculating Valid Passwords...");
                Console.WriteLine("Valid Passwords Count Part 1: " + ValidPasswordsCount(inputList, 1).ToString());
                Console.WriteLine("Valid Passwords Count Part 2: " + ValidPasswordsCount(inputList, 2).ToString());

            }
            catch (Exception exception)
            {
                Console.WriteLine("Error: " + exception.ToString());
            }
        }

        /// <summary>
        /// Calculates the number of valid passwords 
        /// </summary>
        /// <param name="passwordsList"></param>
        /// <returns></returns>
        public static int ValidPasswordsCount(List<string> passwordsList, int partNumber)
        {
            int validPasswordsCount = 0;

            if (partNumber == 1)
            {
                foreach (var inputline in passwordsList)
                {
                    // Get constraints and password
                    var splitLine = inputline.Split();

                    // Constraints 
                    var constraints = splitLine[0].Split('-');
                    int min = Convert.ToInt32(constraints[0]);
                    int max = Convert.ToInt32(constraints[1]);

                    // Values
                    var passwordCharacter = splitLine[1].Trim(':');
                    var password = splitLine[2];

                    // Compare and Count
                    var passwordList = password.ToCharArray().ToList();
                    int charCount = 0;
                    foreach (var character in passwordList)
                    {
                        if (character.ToString().Equals(passwordCharacter))
                        {
                            charCount++;
                        }
                    }

                    // if character is found within min max constraints count++
                    if (charCount >= min && charCount <= max)
                    {
                        validPasswordsCount++;
                    }

                }
            }

            if (partNumber == 2)
            {
                foreach (var inputline in passwordsList)
                {
                    // Get constraints and password
                    var splitLine = inputline.Split();

                    // Constraints 
                    var constraints = splitLine[0].Split('-');
                    int min = Convert.ToInt32(constraints[0]) - 1;
                    int max = Convert.ToInt32(constraints[1]) - 1;
                    

                    // Values
                    var passwordCharacter = splitLine[1].Trim(':');
                    var password = splitLine[2];
                    bool pos1 = false;
                    bool pos2 = false;

                    // Compare and Count
                    var passwordList = password.ToCharArray();

                    if (passwordList[min].ToString().Equals(passwordCharacter))
                    {
                        pos1 = true;
                    }

                    if ( passwordList.Length >= max && passwordList[max].ToString().Equals(passwordCharacter))
                    {
                        pos2 = true;
                    }

                    // if character is found within min max constraints count++
                    if ((pos1.Equals(true) && pos2.Equals(false) ||
                         (pos1.Equals(false) && pos2.Equals(true) )))
                    {
                        validPasswordsCount++;
                    }

                }
            }
            

            return validPasswordsCount;
        }

    }
}
