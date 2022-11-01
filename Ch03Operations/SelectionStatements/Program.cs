int j = 4;

Console.ForegroundColor = ConsoleColor.Yellow;
object o1 = "3";
if (o1 is int i1) {
    Console.WriteLine("o1 is an int so it can multiply!");
    Console.WriteLine($"{i1} x {j} = {i1 * j}");
}
else {
    Console.WriteLine("o1 is not an int so it cannot multiply!");
}

Console.ForegroundColor = ConsoleColor.Cyan;
object o2 = 3;
if (o2 is int i2) {
    Console.WriteLine("o2 is an int so it can multiply:");
    Console.WriteLine($"{i2} x {j} = {i2 * j}");
}
else {
    Console.WriteLine("o2 is not an int so it cannot multiply!");
}

Console.ResetColor();
