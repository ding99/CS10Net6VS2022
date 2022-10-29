using System.Xml;

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

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("- Using infer type");

var xml1 = new XmlDocument();
XmlDocument xml2 = new XmlDocument();
Console.WriteLine($"type of xml1 is {xml1.GetType()}");
Console.WriteLine($"type of xml2 is {xml2.GetType()}");

Console.ForegroundColor = ConsoleColor.DarkYellow;
Console.WriteLine("- Default values");
Console.WriteLine($"default(int) : [{default(int)}]");
Console.WriteLine($"default(bool) : [{default(bool)}]");
Console.WriteLine($"default(DateTime) : [{default(DateTime)}]");
Console.WriteLine($"default(string) : [{default(string)}]");

int n = 10;
Console.WriteLine($"n has been set (by =) to [{n}]");
n = default;
Console.WriteLine($"n has been set (by default) to [{n}]");
