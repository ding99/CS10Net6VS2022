Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("- Check for overflow");

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

Console.ResetColor();
