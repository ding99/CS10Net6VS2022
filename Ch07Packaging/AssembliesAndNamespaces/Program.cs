using System.Xml.Linq; //XDEocument
using System;
using static System.Console;

using Packt.Shared;

ForegroundColor = ConsoleColor.Yellow;

XDocument doc = new();

string s1 = "Hello";
String s2 = "CSharp";
WriteLine($"{s1} {s2}");

WriteLine($"int.MaxValue = {int.MaxValue:N0}");
WriteLine($"nint.MaxValue = {nint.MaxValue:N0}");

ForegroundColor = ConsoleColor.Cyan;

Write("Enter a color value in hex: ");
string? hex = "00ffc8";
WriteLine("Is {0} a valid color value? {1}",
  arg0: hex, arg1: hex.IsValidHex());
Write("Enter a XML element: ");
string? xmlTag = "<h1 class=\"<\" />";
WriteLine("Is {0} a valid XML element? {1}",
  arg0: xmlTag, arg1: xmlTag.IsValidXmlTag());
Write("Enter a password: ");
string? password = "secretsauce";
WriteLine("Is {0} a valid password? {1}",
  arg0: password, arg1: password.IsValidPassWord());

ResetColor();
