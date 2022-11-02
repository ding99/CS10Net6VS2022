using static System.Convert;

Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("- Casting Converting");

int a = 10;
double b = a;
Console.WriteLine($"Cast int {a} to double {b}");

double c = 9.8;
int d = (int)c;
Console.WriteLine($"Cast double {c} to int {d}");
Console.ForegroundColor= ConsoleColor.Cyan;

long e = 10;
int f = (int)e;
Console.WriteLine($"Cast long {e} to int {f}");

e = long.MaxValue;
f = (int)e;
Console.WriteLine($"Cast long {e} to int {f}");

e = 5_000_000_000;
f = (int)e;
Console.WriteLine($"Cast long {e} to int {f}");

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("- using System.Convert");

double g = 9.8;
int h = ToInt32(g);
Console.WriteLine($"g is {g} and ToInt(g) is {h}");

Console.ResetColor();
