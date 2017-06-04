using System;
using System.Collections.Generic;
using System.Linq;

namespace Strings_Making_Anagrams
{
    class Program
    {
        static void Main(string[] args)
        {
            //Get input
            var a = Console.ReadLine();
            var b = Console.ReadLine();

            //Initalize the output
            var nrOfCharsToRemove = 0;

            //Convert strings to lists of char
            var charListA = a.ToCharArray().ToList();
            var charListB = b.ToCharArray().ToList();

            //Create dictionaries from char lists to record the occurrencies of each letter
            var dictionaryA = new Dictionary<char, int>();

            charListA.ForEach(x =>
            {
                if (dictionaryA.ContainsKey(x))
                    dictionaryA[x] += 1;
                else
                    dictionaryA.Add(x, 1);
            });

            var dictionaryB = new Dictionary<char, int>();

            charListB.ForEach(x =>
            {
                if (dictionaryB.ContainsKey(x))
                    dictionaryB[x] += 1;
                else
                    dictionaryB.Add(x, 1);
            });

            //Loop through the letters in a and determine how many does b have of that character if any
            foreach (var key in dictionaryA.Keys)
            {
                if (dictionaryB.ContainsKey(key))
                {
                    //If both strings contains the letter count the difference of the two occurrencies
                    nrOfCharsToRemove += Math.Abs(dictionaryA[key] - dictionaryB[key]);
                }
                else
                {
                    //If only a has the letter count all occurrencies in a
                    nrOfCharsToRemove += dictionaryA[key];
                }
            }

            //Count all other occurrencies of every character only b contains
            nrOfCharsToRemove += dictionaryB.Keys
                                .Where(key => !dictionaryA.ContainsKey(key))
                                .Sum(key => dictionaryB[key]);

            //Log result
            Console.WriteLine(nrOfCharsToRemove);
        }
    }
}
