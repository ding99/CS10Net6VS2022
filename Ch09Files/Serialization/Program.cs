﻿using System.Xml.Serialization;
using Packt.Shared;

using static System.Console;
using static System.Environment;
using static System.IO.Path;

ForegroundColor = ConsoleColor.Yellow;

List<Person> people = new ()
{
    new (30000M)
    {
        FirstName = "Alice",
        LastName = "Smith",
        DateOfBirth = new(1974,3,14)
    },
    new (40000M)
    {
        FirstName = "Bob",
        LastName = "Jones",
        DateOfBirth = new(1969, 11, 23)
    },
    new (20000M)
    {
        FirstName ="Charlie",
        LastName = "Cox",
        DateOfBirth = new(1984,5,4),
        Children = new ()
        {
            new (0M)
            {
                FirstName = "Sally",
                LastName = "Cox",
                DateOfBirth = new(2000,7,12)
            }
        }
    }
};

XmlSerializer xs = new(people.GetType());
string path = Combine (CurrentDirectory, "people.xml");
using FileStream stream = File.Create (path);
xs.Serialize (stream, people);
stream.Close ();

WriteLine("Written {0:N0} bytes of XML to {1}", arg0:new FileInfo(path).Length, arg1:path);
WriteLine();
WriteLine(File.ReadAllText(path));

ForegroundColor = ConsoleColor.Cyan;

using FileStream xmlLoad = File.Open(path, FileMode.Open);
List<Person>? loadedPeople = xs.Deserialize(xmlLoad) as List<Person>;
if(loadedPeople is not null)
    foreach(Person p in loadedPeople)
    {
        WriteLine("{0} has {1} children.", p.LastName, p.Children?.Count??0);
    }

ResetColor ();
