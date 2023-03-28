using System.Diagnostics;

using static System.Console;

ForegroundColor = ConsoleColor.Yellow;

Stopwatch timer = Stopwatch.StartNew();
WriteLine("Running methods synchronously on one thread.");
MethodA();
MethodB();
MethodC();
WriteLine($"{timer.ElapsedMilliseconds:#,##0}ms elapsed.");

ResetColor();

static void OutputThreadInfo()
{
    Thread t = Thread.CurrentThread;
    WriteLine("Thread Id:{0}, Priority:{1}, Background:{2}, Name:{3}", t.ManagedThreadId, t.Priority, t.IsBackground, t.Name ?? "null");
}

static void MethodA()
{
    WriteLine("Starting Method A...");
    OutputThreadInfo();
    Thread.Sleep(3000); // simulate 3 seconds
    WriteLine("Finished Method A.");
}

static void MethodB()
{
    WriteLine("Starting Method B...");
    OutputThreadInfo();
    Thread.Sleep(2000); // simulate 2 seconds
    WriteLine("Finished Method B.");
}

static void MethodC()
{
    WriteLine("Starting Method C...");
    OutputThreadInfo();
    Thread.Sleep(1000); // simulate 1 second
    WriteLine("Finished Method C.");
}


