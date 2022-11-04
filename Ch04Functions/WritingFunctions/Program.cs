Console.ForegroundColor = ConsoleColor.Green;

int n = 15;
var result = CardinalToOrdinal(n);
Console.WriteLine($"The Original of Cardianl {n} is {result}");

Console.ResetColor();

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