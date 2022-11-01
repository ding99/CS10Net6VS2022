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

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("- switch");

int n = (new Random()).Next(1, 7);
Console.WriteLine($"My random number is {n}");
switch (n) {
case 1:
    Console.WriteLine("One");
    break;
case 2:
    Console.WriteLine("Two");
    goto case 1;
case 3:
case 4:
    Console.WriteLine("Three or Four");
    goto case 1;
case 5:
    goto A_label;
default:
    Console.WriteLine("Default");
    break;
}
Console.WriteLine("After end of switch");
A_label:
Console.WriteLine("After A_label");

Console.ResetColor();
