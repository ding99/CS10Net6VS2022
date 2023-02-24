using static System.Console;

ForegroundColor = ConsoleColor.Yellow; WorkingWithLists();

ForegroundColor = ConsoleColor.Cyan; WorkingWithDictionaries();

ResetColor();

static void Output(string title, IEnumerable<string> collection)
{
    Write($"{title}:");
    string.Join(' ', collection);
    foreach(var item in collection)
    {
        Write($" [{item}]");
    }
    WriteLine();
}

static void WorkingWithLists()
{
    List<string> cities = new();
    cities.Add("London");
    cities.Add("Paris");
    cities.Add("Milan");

    Output("Initial list", cities);
    WriteLine($"The first city is {cities[0]}");
    WriteLine($"The last city if {cities[cities.Count - 1]}.");
    cities.Insert(0, "Sydney");
    Output("After inserting Sydney at index 0", cities);
    cities.RemoveAt(1);
    cities.Remove("Milan");
    Output("After removing two cities", cities);
}

static void WorkingWithDictionaries()
{
    Dictionary<string, string> keywords = new()
    {
        {"int", "32-bit integer data type" },
        {"long", "64-bit integer data type" },
        {"float", "Single precision floating point number" },
    };

    Output("Dictionary keys:", keywords.Keys);
    Output("Dictionary values:", keywords.Values);
    foreach(var item in keywords)
        Write($" [{item.Key}:{item.Value}]");
    WriteLine();
    string key = "long";
    WriteLine($"The definition of {key} is {keywords[key]}");
}

