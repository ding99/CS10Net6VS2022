﻿using static System.Console;

ForegroundColor = ConsoleColor.Yellow;

string city = "London";
WriteLine($"{city} is {city.Length} characters long.");
WriteLine($"First char is {city[0]} and third is {city[2]}.");

string cities = "Paris,Tehran,CHennai,Sydney,New York,Medellin";
string[] citiesArray = cities.Split(',');
WriteLine($"There are {citiesArray.Length} items in the array.");
foreach(string item in citiesArray)
{
    WriteLine(item);
}

ForegroundColor = ConsoleColor.Cyan;

string fullname = "Alan Jones";
int indexOfTheSpace = fullname.IndexOf(' ');
string firstName = fullname.Substring(startIndex:0, length:indexOfTheSpace);
string lastName = fullname.Substring(startIndex: indexOfTheSpace + 1);
WriteLine($"Original: {fullname}");
WriteLine($"Swapped: {lastName}, {firstName}");

string company = "Microsoft";
bool startWithM = company.StartsWith("M");
bool containN = company.Contains("N");
WriteLine($"Text: {company}");
WriteLine($"Starts with M: {startWithM}, contains an N: {containN}");

ResetColor();
