using static System.Console;

Console.ForegroundColor = ConsoleColor.Green;
WriteLine("Unary Oprators");
int a = 3;
int b = a++;
int c = ++a;
WriteLine($"a is {a}, b is {b}, c is {c}");
