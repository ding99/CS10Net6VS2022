Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("- Using foreach");

string[] names = { "Adam", "Barry", "Charlie" };
foreach(string name in names) {
    Console.WriteLine($"{name} has {name.Length} characters.");
}

Console.ResetColor();
