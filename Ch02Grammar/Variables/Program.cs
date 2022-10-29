
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("- Using object type");

object height = 1.88;
object name = "Amir";
Console.WriteLine($"name type is {name.GetType()}");
Console.WriteLine($"{name} is {height} metres tall.");

int length2 = ((string)name).Length;
Console.WriteLine($"{name} has {length2} characters.");

Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine("- Using dynamic type");

dynamic something = "Ahmed";
Console.WriteLine($"- something (\"Ahemd\") type is {something.GetType()}");
Console.WriteLine($"Length is {something.Length}");

something = 12;
Console.WriteLine($"- something (12) type is {something.GetType()}");
try {
    Console.WriteLine($"Length is {something.Length}");
}
catch(Exception e) {
    Console.WriteLine(e.Message);
}

something = new[] { 3, 5, 7 };
Console.WriteLine($"- something (new[] {{3,5,7}}) type is {something.GetType()}");
Console.WriteLine($"Length is {something.Length}");


