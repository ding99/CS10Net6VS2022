using static System.Console;

ForegroundColor = ConsoleColor.Yellow;

string[] names = new[] { "Michael" , "Pam", "Jim", "Dwight", "Angela", "Kevin", "Toby", "Creed" };
WriteLine("Deferred execution");

var query = names.Where (name => name.EndsWith ("m"));
string[] result = query.ToArray ();

Write ("- query: ");
foreach (string name in query)
{
    Write($" {name}");
}
WriteLine();

Write ("- result:");
foreach (string name in result)
{
    Write ($" {name}");
}
WriteLine ();

Write ("- query: ");
foreach (string name in query)
{
    Write ($" {name}");
    names[2] = "Jimmy";  // change Jim to Jimmy
}
WriteLine ();

Write ("- result:");
foreach (string name in result)
{
    Write ($" {name}");
}
WriteLine ();

ResetColor ();
