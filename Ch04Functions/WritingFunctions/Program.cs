Console.ForegroundColor = ConsoleColor.Green;

//Console.WriteLine("- Ordinals");
//RunCardinalToOrdinal();

//Console.ForegroundColor = ConsoleColor.Cyan;
//RunFactorials();

Console.ForegroundColor = ConsoleColor.Yellow;
//RunFibImperative();
RunFibFuntional();

Console.ResetColor();

#region Ordinal
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
#endregion

#region Factorial
static void RunFactorials() {
    for (int i = 0; i < 15; i++) {
        try {
            Console.WriteLine($"{i}! = {Factorial(i):N0}");
        }
        catch(OverflowException) {
            Console.WriteLine($"{i}! is too big for a 32-bit integer.");
        }
    }
}

static int Factorial(int n) {
    if (n < 1) {
        return 0;
    }
    else if (n == 1) {
        return 1;
    }
    else {
        checked {
            return Factorial(n - 1) * n;
        }
    }
}
#endregion

#region Fibonacci
static void RunFibImperative() {
    for (int i = 1; i < 30; i++) {
        Console.WriteLine("The {0} term of the Fibonacci sequence is {1:N0}.", arg0:CardinalToOrdinal(i), arg1:FibImperative(term:i));
    }
}

static int FibImperative(int term) {
    if (term == 1) {
        return 0;
    }
    else if (term == 2) {
        return 1;
    } else {
        return FibImperative(term - 1) + FibImperative(term - 2);
    }
}

static void RunFibFuntional() {
    for (int i = 1; i < 30; i++) {
        Console.WriteLine("The {0} term of the Fibonacci sequence is {1:N0}.", arg0: CardinalToOrdinal(i), arg1: FibImperative(term: i));
    }
}

static int FibFunctional(int term) =>
    term switch {
        1 => 0,
        2 => 1,
        _ => FibFunctional(term - 1) + FibFunctional(term - 2)
    };
#endregion
