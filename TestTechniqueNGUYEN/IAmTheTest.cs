using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTechniqueNGUYEN
{
    internal class IAmTheTest : IIAmTheTest
    {
        public IEnumerable<string> GetSuggestions(string term, IEnumerable<string> choices, int numberOfSuggestions)
        {
            term = term.ToLower();

            var matches = choices.Where(x => x.ToLower().Contains(term))
                .OrderBy(x => x.Length)
                .ThenBy(x => x.ToLower())
                .Take(numberOfSuggestions)
                .ToList();

            if (matches.Count >= numberOfSuggestions)
                return matches;

            var numberRemaining = numberOfSuggestions - matches.Count;
            var othersResults = choices.Except(matches)
                .Where(x => x.Length >= term.Length)
                .Select(x =>
                {
                    int diff = 0;
                    for (int i = 0; i < term.Length; i++)
                    {
                        if (term[i] != x[i])
                            diff++;
                    }
                    int lengthDiff = Math.Abs(x.Length - term.Length);
                    return (word: x, diff, lengthDiff);
                })
                .OrderBy(y => y.diff)
                .ThenBy(y => y.lengthDiff)
                .ThenBy(y => y.word)
                .Take(numberRemaining)
                .Select(y => y.word);

            matches.AddRange(othersResults);

            return matches;
        }
    }
}
