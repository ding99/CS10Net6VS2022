using System.Diagnostics;

using static System.Console;

ForegroundColor = ConsoleColor.Yellow;

WriteLine("Please wait for the tasks to complete.");
Stopwatch watch = Stopwatch.StartNew();
Task a = Task.Factory.StartNew(MethodA);
Task b = Task.Factory.StartNew(MethodB);

Task.WaitAll(new[] {a, b });
WriteLine();
WriteLine($"Results:{SharedObjects.Message}");
WriteLine($"{watch.ElapsedMilliseconds:N0} elapsed milliseconds.");
ResetColor();

static void MethodA()
{
    try
    {
        if (Monitor.TryEnter(SharedObjects.Conch, TimeSpan.FromSeconds(15)))
        {
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(SharedObjects.Random.Next(2000));
                SharedObjects.Message += "A";
                Write(".");
            }
        }
        else
        {
            WriteLine("Method A timed out when entering a monitor on conch.");
        }
    }
    finally
    {
        Monitor.Exit(SharedObjects.Conch);
    }
}

static void MethodB()
{
    try
    {
        if (Monitor.TryEnter(SharedObjects.Conch, TimeSpan.FromSeconds(15)))
        {
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(SharedObjects.Random.Next(2000));
                SharedObjects.Message += "B";
                Write(".");
            }
        }
        else
        {
            WriteLine("Method B timed out when entering a monitor on conch.");
        }
    }
    finally
    {
        Monitor.Exit(SharedObjects.Conch);
    }
}

static class SharedObjects
{
    public static Random Random = new();
    public static string? Message; // a shared resource
    public static object Conch = new();
}
