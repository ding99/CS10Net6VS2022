﻿using System.Diagnostics;

using static System.Console;

ForegroundColor = ConsoleColor.Yellow;

Stopwatch watch = new();
Write("Press ENTER to start.");
ReadLine();
watch.Start();
int max = 45;
IEnumerable<int> numbers = Enumerable.Range(start:1, count:max);
WriteLine($"Calculating Fibonacci sequence up to {max}. Please wait...");
//int[] fibonacciNumbers = numbers
//    .Select(n => Fibonacci(n))
//    .ToArray();
int[] fibonacciNumbers = numbers
    .AsParallel()
    .Select(n => Fibonacci(n))
    .OrderBy(n => n)
    .ToArray();
watch.Stop();
WriteLine("{0:#,##0} elapsed milliseconds.",
    arg0:watch.ElapsedMilliseconds);
Write("Results:");
foreach(int n in fibonacciNumbers) Write($" {n}");

ResetColor();

static int Fibonacci(int term) => term switch
{
    1 => 0,
    2 => 1,
    _ => Fibonacci(term - 1) + Fibonacci(term - 2)
};