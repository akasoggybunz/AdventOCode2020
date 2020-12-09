using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace Day4
{
    /// <summary>
    /// Day 4
    /// </summary>
    class Program
    {
        /// <summary>
        /// Validation
        /// </summary>
        private static readonly IDictionary<string, string> PassportFields = new Dictionary<string, string>
        {
            {"byr", @"^(19[2-8][0-9]|199[0-9]|200[0-2])$"},
            {"iyr", @"^(201[0-9]|2020)$"},
            {"eyr", @"^(202[0-9]|2030)$"},
            {"hgt", @"^(((1[5-8][0-9]|19[0-3])cm)|((59|6[0-9]|7[0-6])in))$"},
            {"hcl", @"^#[0-9a-fA-F]{6}$"},
            {"ecl", @"^(amb|blu|brn|gry|grn|hzl|oth)$"},
            {"pid", @"^\d{9}$"}
        };


        /// <summary>
        /// Main
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine(" ~~~ Advent of Code Day 4!!! ~~~");
            List<string> inputList = new List<string>();
            
            // Grab Input
            try
            {
                Console.WriteLine(" ~~~ Reading input file");
                //long totalTreesHit = 0;

                using StreamReader sr = new StreamReader("./input.txt");
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    //Console.WriteLine(line);
                    inputList.Add(line);
                }
                // This while and foreach could be together.. but bollocks 
                Console.WriteLine("Calculating...");
                Console.WriteLine("Valid Passports: " + ValidPassportCount(inputList, requiredFields, optionalFields));
            }
            catch (Exception exception)
            {
                Console.WriteLine("Error: " + exception.ToString());
            }
        }

        /// <summary>
        /// Validate Passports
        /// </summary>
        /// <param name="inputList"></param>
        /// <param name="validationList"></param>
        /// <returns></returns>
        public static int ValidPassportCount(List<string> inputList, List<string> validationList, List<String> optionalValuesList)
        {
            int count = 0;

            string currentPasport = "";
            bool passportReady = false;
            


            // remove optional fields from validation list
            var common = validationList.Intersect(optionalValuesList).ToList();
            validationList.RemoveAll(x=> common.Contains(x));

            foreach (var line in inputList)
            {
                // Grab passport
                if (!string.IsNullOrEmpty(line))
                {
                    currentPasport += line + " ";
                }
                else
                {
                    passportReady = true;
                }

                // Validate Password
                if (passportReady)
                {
                    var passportValues = currentPasport.Split().ToList();
                    passportValues.RemoveAt(passportValues.Count-1);

                    // trim
                    var temp = new List<string>();
                    foreach (var pv in passportValues)
                    {
                      var s =  pv.Split(':');
                       temp.Add(s[0]);
                    }

                    passportValues = temp;

                    // Remove optional
                    passportValues.RemoveAll(x => common.Contains(x));

                    //var c = passportValues.Count(pv => validationList.Any(pv.Contains));
                    bool valid = passportValues.Intersect(validationList).Count().Equals(validationList.Count);
                    valid = passportValues.Contains( )


                    //if (c >= validationList.Count) count++;
                    if (valid) count++;

                    passportReady = false;
                    currentPasport = "";
                }
                
            }

            return count;
        }
    }
}
