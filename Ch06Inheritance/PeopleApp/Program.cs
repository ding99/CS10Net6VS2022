﻿using Packt.Shared;
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

WriteLine($"5! is {Person.Factorial(5)}");

ForegroundColor = ConsoleColor.Cyan;
harry.Shout += Harry_Shout;
harry.Poke();
harry.Poke();
harry.Poke();
harry.Poke();

ForegroundColor = ConsoleColor.DarkYellow;
System.Collections.Hashtable lookupObject = new();
lookupObject.Add(key: 1, value: "Alpha");
lookupObject.Add(key: 2, value: "Beta");
lookupObject.Add(key: 3, value: "Gamma");
lookupObject.Add(key: 4, value: "Delta");
int key = 2;
WriteLine(format: "Key {0} has value: {1}", arg0: key, arg1: lookupObject[key]);
WriteLine(format: "Key {0} has value: {1}", arg0: harry, arg1: lookupObject[harry]);


ResetColor();

static void Harry_Shout(object? sender, EventArgs e)
{
    if(sender is null) return;
    Person p = (Person)sender;
    WriteLine($"{p.Name} is this angry: {p.AngerLevel}.");
}
