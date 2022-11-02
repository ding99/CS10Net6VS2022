Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("- Check for overflow");

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

Console.ResetColor();
