static double Add(double a, double b) {
    return a * b;
}

Console.ForegroundColor = ConsoleColor.Yellow;
double a = 4.5;
double b = 2.5;
double answer = Add(a, b);
Console.WriteLine($"{a} + {b} = {answer}");

Console.ResetColor();
