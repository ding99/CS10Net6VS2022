Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("- Handling exceptions");

Console.WriteLine("Before parsing");
string? input = Console.ReadLine();
Console.WriteLine($"input is {input}");

Console.WriteLine("What is your age?");
try {
    int age = int.Parse(input);
    Console.WriteLine($"You are {age} years old.");
}
catch {
}
Console.WriteLine("After parsing");

Console.ResetColor();
