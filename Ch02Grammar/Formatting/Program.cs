Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("- Numbered positional arguments");

int number = 12;
decimal price = 0.35M;
Console.WriteLine(
    format:"{0} apples costs {1:C}",
    arg0:number,
    arg1:price * number);
string formatted = string.Format(
    format: "{0} apples costs {1:C}",
    arg0: number,
    arg1: price * number);
Console.WriteLine(formatted);
Console.WriteLine($"{number} apples costs {price * number:C}");

Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine("- Format strings");

string applesText = "Apples";
int applesCount = 1234;
string bananasText = "Bananas";
int bananasCount = 56789;
Console.WriteLine(format:"{0,-10} {1,6:N0}", arg0:"Name", arg1:"Count");
Console.WriteLine(format: "{0,-10} {1,6:N0}", arg0: applesText, arg1: applesCount);
Console.WriteLine(format: "{0,-10} {1,6:N0}", arg0: bananasText, arg1: bananasCount);

Console.ResetColor();