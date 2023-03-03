using System.Xml.Serialization;
using Packt.Shared;
using NewJson = System.Text.Json.JsonSerializer;

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
string xmlPath = Combine (CurrentDirectory, "people.xml");
using FileStream xmlStream = File.Create (xmlPath);
xs.Serialize (xmlStream, people);
xmlStream.Close ();

WriteLine("Written {0:N0} bytes of XML to {1}", arg0:new FileInfo(xmlPath).Length, arg1:xmlPath);
WriteLine();
WriteLine(File.ReadAllText(xmlPath));

ForegroundColor = ConsoleColor.Cyan;

using FileStream xmlLoad = File.Open(xmlPath, FileMode.Open);
List<Person>? loadedPeople = xs.Deserialize(xmlLoad) as List<Person>;
if(loadedPeople is not null)
    foreach(Person p in loadedPeople)
    {
        WriteLine("{0} has {1} children.", p.LastName, p.Children?.Count??0);
    }

ForegroundColor = ConsoleColor.Green;

string jsonPath = Combine (CurrentDirectory, "people.json");
using StreamWriter jsonStream = File.CreateText(jsonPath);
Newtonsoft.Json.JsonSerializer jss = new ();
jss.Serialize(jsonStream, people);
jsonStream.Close ();

WriteLine();
WriteLine("Written {0:N0} bytes of JSON to: {1}", arg0:new FileInfo(jsonPath).Length, arg1:jsonPath);
WriteLine(File.ReadAllText(jsonPath));

ForegroundColor = ConsoleColor.DarkYellow;

using FileStream jsonLoad = File.Open(jsonPath, FileMode.Open);
List<Person>? jsonloadedPeople = await NewJson.DeserializeAsync(utf8Json:jsonLoad, returnType:typeof(List<Person>)) as List<Person>;
if(jsonloadedPeople is not null)
    foreach(Person p in jsonloadedPeople)
    {
        WriteLine("{0} has {1} children.", p.LastName, p.Children?.Count??0);
    }

ResetColor ();
