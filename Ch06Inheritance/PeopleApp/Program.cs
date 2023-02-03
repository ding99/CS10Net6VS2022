using Packt.Shared;
using static System.Console;

ForegroundColor = ConsoleColor.Yellow;

Person harry = new() { Name = "Harry" };
Person mary = new() { Name = "Mary" };
Person jill = new() { Name = "Jill" };
// call instance method
Person baby1 = mary.ProcreateWith(harry);
baby1.Name = "Gary";
// call static mehtod
Person baby2 = Person.Procreate(harry, jill);
// call an operator
Person baby3 = harry * mary;

WriteLine($"{harry.Name} has {harry.Children.Count} children.");
WriteLine($"{mary.Name} has {mary.Children.Count} children.");
WriteLine($"{jill.Name} has {jill.Children.Count} children.");
WriteLine(format:"{0}'s first child is named \"{1}\".",
    arg0:harry.Name,
    arg1: harry.Children[0].Name);

ForegroundColor = ConsoleColor.Cyan;

WriteLine($"5! is {Person.Factorial(5)}");

ResetColor();
