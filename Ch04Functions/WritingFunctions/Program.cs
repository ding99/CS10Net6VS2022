Console.ForegroundColor = ConsoleColor.Green;

Console.WriteLine("- Ordinals");
RunCardinalToOrdinal();

Console.ForegroundColor = ConsoleColor.Cyan;
RunFactorials();

Console.ResetColor();

static void RunCardinalToOrdinal() {
    for(int i = 1; i <= 40; i++) {
        Console.Write($"{CardinalToOrdinal(i)} ");
    }
    Console.WriteLine();
}

static string CardinalToOrdinal(int number) {
    switch (number) {
    case 11:
    case 12:
    case 13:
        return $"{number}th";
        default:
        int lastDigit = number % 10;
        string suffix = lastDigit switch {
            1 => "st",
            2 => "nd",
            3 => "rd",
            _ => "th"
        };
        return $"{number}{suffix}";
    }
}

static void RunFactorials() {
    for (int i = 0; i < 10; i++) {
        Console.WriteLine($"{i}! = {Factorial(i):N0}");
    }
}

static int Factorial(int n) {
    return n switch {
        0 => 0,
        1 => 1,
        _ => Factorial(n - 1) * n
    };
}