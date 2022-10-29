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

Console.ResetColor();