using BenchmarkDotNet.Running;

using static System.Console;

ForegroundColor = ConsoleColor.Yellow;

BenchmarkRunner.Run<StringBenchmarks>();

ResetColor();
