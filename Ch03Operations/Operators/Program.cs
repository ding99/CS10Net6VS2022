using static System.Console;

ForegroundColor = ConsoleColor.Green;
WriteLine("Unary Oprators");
int a = 3;
int b = a++;
int c = ++a;
WriteLine($"a is {a}, b is {b}, c is {c}");

ForegroundColor = ConsoleColor.Yellow;
double g = 11.0;
int f = 3;
WriteLine($"g is {g:N1}, f is {f}");
WriteLine($"g /f = {g / f}");

ResetColor();
