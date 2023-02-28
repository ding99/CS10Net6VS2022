using System.Collections.Immutable;
using static System.Console;

ForegroundColor = ConsoleColor.Yellow; WorkingWithLists();
ForegroundColor = ConsoleColor.Cyan; WorkingWithDictionaries();
ForegroundColor = ConsoleColor.Green; WorkingWithQueues();
ForegroundColor = ConsoleColor.DarkYellow; WorkingWithPriorityQueues();

ResetColor();

static void Output(string title, IEnumerable<string> collection)
{
    Write($"{title}:");
    foreach(var item in collection)
        Write($" [{item}]");
    WriteLine();
}

static void OutputPQ<TElement, TPriority>(string title, IEnumerable<(TElement Element, TPriority Priority)> collection)
{
    Write($"{title}:");
    foreach((TElement, TPriority) item in collection)
        Write($" [{item.Item1}:{item.Item2}]");
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

    ImmutableList<string> immutableCities = cities.ToImmutableList();
    ImmutableList<string> newList = immutableCities.Add("Rio");
    Output("Immutable list of cities", immutableCities);
    Output("New list of cities", newList);
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

static void WorkingWithQueues()
{
    Queue<string> coffee = new();
    coffee.Enqueue("Damir");
    coffee.Enqueue("Andrea");
    coffee.Enqueue("Ronald");
    coffee.Enqueue("Amin");
    coffee.Enqueue("Irina");
    Output("Initial queue from front to back", coffee);

    string served = coffee.Dequeue();
    WriteLine($"Served: [{served}]");
    served = coffee.Dequeue();
    WriteLine($"Served: [{served}]");
    Output("Current queue from front to back", coffee);
    WriteLine($"{coffee.Peek()} is next in line.");
    Output("Current queue from front to back", coffee);
}

static void WorkingWithPriorityQueues()
{
    PriorityQueue<string, int> vaccine = new();
    vaccine.Enqueue("Pamela", 1);
    vaccine.Enqueue("Rebecca", 3);
    vaccine.Enqueue("Juliet", 2);
    vaccine.Enqueue("Ian", 1);

    OutputPQ("Current queue for vaccination", vaccine.UnorderedItems);
    WriteLine($"[{vaccine.Dequeue()}] has been vaccinated.");
    WriteLine($"[{vaccine.Dequeue()}] has been vaccinated.");
    OutputPQ("Current queue for vaccination", vaccine.UnorderedItems);
    WriteLine($"[{vaccine.Dequeue()}] has been vaccinated.");
    vaccine.Enqueue("Mark", 2);
    WriteLine($"[{vaccine.Peek()}] will be next to be vaccinated.");
    OutputPQ("Current queue for vaccination", vaccine.UnorderedItems);
}

