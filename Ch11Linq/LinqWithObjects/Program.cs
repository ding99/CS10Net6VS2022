using static System.Console;

ForegroundColor = ConsoleColor.Yellow;

string[] names = new[] { "Michael" , "Pam", "Jim", "Dwight", "Angela", "Kevin", "Toby", "Creed" };
WriteLine("Deferred execution");

var query1 = names.Where (name => name.EndsWith ("m"));
var query2 = from name in names where name.EndsWith ("m") select name;

string[] result1 = query1.ToArray ();
List<string> result2 = query2.ToList ();

Write("- query1:");
foreach (string name in query1)
{
    Write($" {name}");
}
WriteLine();

Write ("- query2:");
foreach (string name in query2)
{
    Write ($" {name}");
    names[2] = "Jimmy";  // change Jim to Jimmy
}
WriteLine ();

ResetColor ();
