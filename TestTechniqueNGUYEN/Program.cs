// See https://aka.ms/new-console-template for more information
using TestTechniqueNGUYEN;

class Program
{
    static void Main()
    {
        IAmTheTest search = new IAmTheTest();

        var choices = new List<string> { "gros", "gras", "graisse", "agressif", "go", "ros", "gro" };
        string term = "gros";
        int n = 3;

        var results = search.GetSuggestions(term, choices, n);

        Console.WriteLine("Suggestions:");
        foreach (var r in results)
        {
            Console.WriteLine(r);
        }
    }
}
