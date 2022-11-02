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

double[] doubles = new[] { 9.49, 9.5, 9.51, 10.49, 10.5, 10.51 };
foreach(double n in doubles) {
    Console.WriteLine($"ToInt32({n}) is {ToInt32(n)}");
}

foreach(double n in doubles) {
    Console.WriteLine(format:"Math.Round({0}, 0, MidpointRounding.AwayFromZero) is {1}",
      arg0:n,
      arg1:Math.Round(value:n,digits:0,mode:MidpointRounding.AwayFromZero));
}

Console.ResetColor();
