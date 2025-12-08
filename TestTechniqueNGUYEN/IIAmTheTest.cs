using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTechniqueNGUYEN
{
    internal interface IIAmTheTest
    {
        IEnumerable<string> GetSuggestions(string term, IEnumerable<string> choices, int numberOfSuggestions);
    }
}
