﻿using System.Xml.Linq; //XDEocument
using System;
using static System.Console;

using Packt.Shared;
using DialectSoftware.Collections;
using DialectSoftware.Collections.Generics;

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

ForegroundColor = ConsoleColor.DarkYellow;

Axis x = new("x", 0, 10, 1);
Axis y = new("y", 0, 4, 1);
Matrix<long> matrix = new(new[] { x, y });
for(int i = 0; i < matrix.Axes[0].Points.Length; i++)
{
    matrix.Axes[0].Points[i].Label = "x" + i.ToString();
}
for(int i = 0; i < matrix.Axes[1].Points.Length; i++)
{
    matrix.Axes[1].Points[i].Label = "y" + i.ToString();
}
foreach(long[] c in matrix)
{
    matrix[c] = c[0] + c[1];
}
foreach(long[] c in matrix)
{
    WriteLine("{0},{1} ({2},{3}) = {4}",
        matrix.Axes[0].Points[c[0]].Label,
        matrix.Axes[1].Points[c[01]].Label,
        c[0], c[1], matrix[c]);
}

ResetColor();
