using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Two_Characters
{
    class Program
    {
        private static void Main(String[] args)
        {
            //Get input
            var lengthOfS = Convert.ToInt32(Console.ReadLine());
            var s = Console.ReadLine();
            //Log output
            Console.WriteLine(GetLongestValidT(s));
        }

        //Main logic
        private static int GetLongestValidT(string s)
        {
            //Create hash set from string two see all the distinct characters
            var distinctCharsInS = new HashSet<char>(s).ToArray();

            //Make pairs of the letters in all possible combination
            var tCandidatePairs = MakePairs(distinctCharsInS);

            //Make string t of the pairs and see if they are valid
            var validTs = CreateValidTs(s, tCandidatePairs);

            //Find the longest valid t (or zero if none was returned)
            var longestValidTLength = validTs.Count > 0 ? validTs.Max(x => x.Length) : 0;

            return longestValidTLength;
        }

        private static List<char[]> MakePairs(char[] s)
        {
            var pairs = new List<char[]>();

            //for every letter
            for (var i = 0; i < s.Length; i++)
            {
                //pair the other
                for (var j = i + 1; j < s.Length; j++)
                {
                    pairs.Add(new[] { s[i], s[j] });
                }
            }

            return pairs;
        }

        //Create a t string from every possible character pair and validate
        private static List<string> CreateValidTs(string s, List<char[]> tCandidateCharPairs)
        {
            var validTs = new List<string>();

            //for every character pair
            tCandidateCharPairs.ForEach(chPair =>
            {
                //to create a t candidate
                //make a string from the original by removing every letter except from the two in the pair
                var tCandidate = string.Concat(s.Where(chPair.Contains));
                //so we end up with a string composed of only 2 letters keeping the original sequence

                //then validate
                if (IsValidT(tCandidate))
                    validTs.Add(tCandidate);
            });

            return validTs;
        }

        private static bool IsValidT(string tCandidate)
        {
            var previous = '\0';

            //not valid if the same character appears two times in a row
            foreach (var c in tCandidate)
            {
                if (c == previous)
                    return false;
                previous = c;
            }

            //otherwise valid
            return true;
        }
    }
}
