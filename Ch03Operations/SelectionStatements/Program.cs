Console.ForegroundColor = ConsoleColor.Yellow;

object o = "3";
int j = 4;
if (o is int i) {
    Console.WriteLine($"{i} x {j} = {i * j}");
}
else {
    Console.WriteLine("nothing");
}

Console.ResetColor();
