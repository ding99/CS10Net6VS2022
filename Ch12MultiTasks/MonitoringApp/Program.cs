using System.Text;
using Packt.Shared;

using static System.Console;

ForegroundColor = ConsoleColor.Yellow;

WriteLine("Processing. Please wait...");
Recorder.Start();
int[] largeArrayOfInts = Enumerable.Range(start: 1, count: 10_000).ToArray();
Thread.Sleep(new Random().Next(5, 10) * 1000);
Recorder.Stop();

ForegroundColor = ConsoleColor.Cyan;

int[] numbers = Enumerable.Range(start:1,count:50_000).ToArray();
WriteLine("- Using string with +");
Recorder.Start();
string s = string.Empty;
for (int i = 0; i < numbers.Length; i++)
    s += numbers[i] + ",";
Recorder.Stop();

WriteLine("- Using StringBuilder");
Recorder.Start();
StringBuilder builder = new();
for (int i = 0; i < numbers.Length; i++)
    builder.Append(numbers[i]).AppendLine(",");
Recorder.Stop();

ResetColor();
