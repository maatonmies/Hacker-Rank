using System;
using System.Collections.Generic;
using System.Linq;

namespace HashTables_Ransom_Note
{
    class Program
    {
        static void Main(string[] args)
        {
            //Get input
            var tokens_m = Console.ReadLine().Split(' ');
            var magazine = Console.ReadLine().Split(' ').ToList();
            var ransom = Console.ReadLine().Split(' ').ToList();

            //Make dictionaries of the strings recording the occurrencies of each character
            var magazineDict = new Dictionary<string, int>();

            magazine.ForEach(x =>
            {
                if (!magazineDict.Keys.Contains(x))
                    magazineDict.Add(x, 1);
                else
                    magazineDict[x] += 1;
            });

            var ransomDict = new Dictionary<string, int>();

            ransom.ForEach(x =>
            {
                if (!ransomDict.Keys.Contains(x))
                    ransomDict.Add(x, 1);
                else
                    ransomDict[x] += 1;
            });

            //Loop through the ransom note's words and find out if the magazine has the
            //same amount or more of those words and score each match
            var score = ransomDict.Keys
                                   .Count(key => magazineDict.ContainsKey(key) 
                                    && magazineDict[key] >= ransomDict[key]);

            //Log out the result
            Console.WriteLine(score >= ransomDict.Count ? "Yes" : "No");
        }
    }
}
