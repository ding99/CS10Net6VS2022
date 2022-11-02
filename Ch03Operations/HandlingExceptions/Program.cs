Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("- Handling exceptions");

Console.WriteLine("Before parsing");
string? input = "twenty";
Console.WriteLine($"input is {input}");

Console.WriteLine("What is your age?");
try {
    int age = int.Parse(input);
    Console.WriteLine($"You are {age} years old.");
}
catch (FormatException) {
    Console.WriteLine("The age you entered is not a valid number format");
}
catch(Exception ex) {
    Console.WriteLine($"{ex.GetType()} says {ex.Message}");
}
Console.WriteLine();

input = "9876543210";
Console.WriteLine($"input is {input}");
try {
    int age = int.Parse(input);
    Console.WriteLine($"You are {age} years old.");
}
catch (OverflowException) {
    Console.WriteLine("Your age is a valid number format it is either too big or small");
}
catch (FormatException) {
    Console.WriteLine("The age you entered is not a valid number format");
}
catch (Exception ex) {
    Console.WriteLine($"{ex.GetType()} says {ex.Message}");
}
Console.WriteLine("After parsing");

Console.ResetColor();
