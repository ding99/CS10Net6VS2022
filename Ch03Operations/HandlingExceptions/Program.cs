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
Console.WriteLine();

Console.ForegroundColor = ConsoleColor.Magenta;
input = "$230";
Console.WriteLine($"input is {input}");
try {
    decimal amount = decimal.Parse(input);
    Console.WriteLine($"The amount is {amount}.");
}
catch (FormatException ex) when (input.Contains("$")) {
    Console.WriteLine("Amounts cannot use the dollar sign!");
    Console.WriteLine(ex.Message);
}
catch (FormatException) {
    Console.WriteLine("Amounts must only contain digits!");
}
catch (Exception ex) {
    Console.WriteLine($"{ex.GetType()} says {ex.Message}");
}
Console.WriteLine();

Console.ForegroundColor = ConsoleColor.Green;
input = "a230";
Console.WriteLine($"input is {input}");
try {
    decimal amount = decimal.Parse(input);
    Console.WriteLine($"The amount is {amount}.");
}
catch (FormatException) when (input.Contains("$")) {
    Console.WriteLine("Amounts cannot use the dollar sign!");
}
catch (FormatException) {
    Console.WriteLine("Amounts must only contain digits!");
}
catch (Exception ex) {
    Console.WriteLine($"{ex.GetType()} says {ex.Message}");
}
Console.WriteLine();

Console.ForegroundColor = ConsoleColor.DarkYellow;
input = "230";
Console.WriteLine($"input is {input}");
try {
    decimal amount = decimal.Parse(input);
    Console.WriteLine($"The amount is {amount}.");
}
catch (FormatException) when (input.Contains("0")) {
    Console.WriteLine("Amounts cannot use zero!");
}
catch (Exception ex) {
    Console.WriteLine($"{ex.GetType()} says {ex.Message}");
}
Console.WriteLine("After parsing");

Console.ResetColor();
