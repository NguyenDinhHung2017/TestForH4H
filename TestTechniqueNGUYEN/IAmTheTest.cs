using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTechniqueNGUYEN
{
    public class IAmTheTest : IIAmTheTest
    {
        public IEnumerable<string> GetSuggestions(string term,IEnumerable<string> choices,int numberOfSuggestions)
        {
            term = term.ToLower();

            var matches = choices
                .Where(x => x.ToLower().Contains(term))
                .OrderBy(x => x.Length)
                .ThenBy(x => x.ToLower())
                .Take(numberOfSuggestions)
                .ToList();

            if (matches.Count >= numberOfSuggestions)
                return matches;

            var numberRemaining = numberOfSuggestions - matches.Count;

            var otherResults = choices
                .Except(matches)
                .Where(x => x.Length >= term.Length)
                .Select(x => new
                {
                    Word = x,
                    Diff = CalculateDifferenceScore(term, x),
                    LengthDiff = Math.Abs(x.Length - term.Length)
                })
                .OrderBy(x => x.Diff)
                .ThenBy(x => x.LengthDiff)
                .ThenBy(x => x.Word)
                .Take(numberRemaining)
                .Select(x => x.Word);

            matches.AddRange(otherResults);

            return matches;
        }

        public static int CalculateDifferenceScore(string term, string word)
        {
            term = term.ToLower();
            word = word.ToLower();
                        
            if (word.Length < term.Length)
            {
                return int.MaxValue;
            }

            int minDiff = int.MaxValue;
            
            for (int start = 0; start <= word.Length - term.Length; start++)
            {
                int diff = 0;
                for (int i = 0; i < term.Length; i++)
                {
                    if (term[i] != word[start + i])
                        diff++;
                }

                minDiff = Math.Min(minDiff, diff);
            }

            return minDiff;
        }
    }
}
