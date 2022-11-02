Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("- checked for overflow");

try {
    checked {
        int x = int.MaxValue - 1;
        Console.WriteLine($"Initial value: {x}");
        x++;
        Console.WriteLine($"After incrementing: {x}");
        x++;
        Console.WriteLine($"After incrementing: {x}");
        x++;
        Console.WriteLine($"After incrementing: {x}");
    }
}
catch (OverflowException) {
    Console.WriteLine($"The code overflowed but I caught the exception.");
}

Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("- unckecked");
unchecked {
    int y = int.MaxValue + 1;
    Console.WriteLine($"Initial value: {y}");
    y--;
    Console.WriteLine($"After decrementing: {y}");
    y--;
    Console.WriteLine($"After decrementing: {y}");
}

Console.ResetColor();
