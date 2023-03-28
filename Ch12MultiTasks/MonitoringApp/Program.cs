using Packt.Shared;

using static System.Console;

ForegroundColor = ConsoleColor.Yellow;

WriteLine("Processing. Please wait...");
Recorder.Start();

int[] largeArrayOfInts = Enumerable.Range(start:1, count:10_000).ToArray();
Thread.Sleep(new Random().Next(5,10)*1000);
Recorder.Stop();

ResetColor();
