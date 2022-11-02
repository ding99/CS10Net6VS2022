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

Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine("- double division");
double x1 = 10, y1 = 0;
try {
    double z1 = x1 / y1;
    Console.WriteLine($"double: {x1} / {y1} = {z1}");
}
catch(Exception e) {
    Console.WriteLine(e.Message);
}

Console.WriteLine("- integer division");
int x2 = 10, y2 = 0;
try {
    int z2 = x2 / y2;
    Console.WriteLine($"int: {x2} / {y2} = {z2}");
}
catch (Exception e) {
    Console.WriteLine(e.Message);
}

Console.ResetColor();
