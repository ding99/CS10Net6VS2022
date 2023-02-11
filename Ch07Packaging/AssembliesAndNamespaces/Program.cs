using System.Xml.Linq; //XDEocument
using System;
using static System.Console;

XDocument doc = new();

string s1 = "Hello";
String s2 = "CSharp";
WriteLine($"{s1} {s2}");

WriteLine($"int.MaxValue = {int.MaxValue:N0}");
WriteLine($"nint.MaxValue = {nint.MaxValue:N0}");
