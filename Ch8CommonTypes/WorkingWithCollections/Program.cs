using static System.Console;

ForegroundColor = ConsoleColor.Yellow;
WorkingWithLists();
ResetColor();

static void Output(string title, IEnumerable<string> collection)
{
    Write($"{title}:");
    string.Join(' ', collection);
    foreach(var item in collection)
    {
        Write($" {item}");
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

