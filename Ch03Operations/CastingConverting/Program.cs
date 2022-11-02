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

Console.ForegroundColor = ConsoleColor.DarkCyan;
Console.WriteLine("- ToString()");

int number = 12; Console.WriteLine($"[{number}] to [{number.ToString()}]");
bool boolean = true; Console.WriteLine($"[{boolean}] to [{boolean.ToString()}]");
DateTime now = DateTime.Now; Console.WriteLine($"[{now}] to [{now.ToString()}]");
object me = new(); Console.WriteLine($"[{me}] to [{me.ToString()}]");

Console.ForegroundColor = ConsoleColor.DarkYellow;
byte[] binaryObject = new byte[128];
(new Random()).NextBytes(binaryObject);
Console.WriteLine("Binary Object as bytes:");
for (int i = 0; i < binaryObject.Length; i++) {
    Console.Write($"{binaryObject[i]:X} ");
}
Console.WriteLine();
string encoded = ToBase64String(binaryObject);
Console.WriteLine($"Binary Object as Base64: {encoded}");

Console.ForegroundColor = ConsoleColor.Cyan;
int age = int.Parse("27");
DateTime birthday = DateTime.Parse("4 July 1980");
Console.WriteLine($"I was born {age} years ago.");
Console.WriteLine($"My birthday is {birthday}.");
Console.WriteLine($"My birthday is {birthday:D}");

string v1 = "abc";
try {
    int count = int.Parse(v1);
    Console.WriteLine($"parse {v1} to {count}");
}
catch(Exception ex) {
    Console.WriteLine(ex.Message);
}

Console.ForegroundColor = ConsoleColor.DarkCyan;
string? input = "12";
Console.WriteLine($"- How many eggs are there? (using TryParse). input is {input}");
if(int.TryParse(input, out int eggs)) {
    Console.WriteLine($"There are {eggs} eggs.");
}
else {
    Console.WriteLine("I could not parse the input.");
}

input = "Twelve";
Console.WriteLine($"- How many eggs are there? (using TryParse). input is {input}");
if (int.TryParse(input, out int eggs2)) {
    Console.WriteLine($"There are {eggs2} eggs.");
}
else {
    Console.WriteLine("I could not parse the input.");
}

Console.ResetColor();
