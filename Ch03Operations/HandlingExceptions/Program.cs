Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("- Handling exceptions");

Console.WriteLine("Before parsing");
string? input = "49";
Console.WriteLine($"input is {input} with type of {input.GetType()}");

Console.WriteLine("What is your age?");
try {
    int age = int.Parse(input);
}
catch {
}
Console.WriteLine("After parsing");

Console.ResetColor();
