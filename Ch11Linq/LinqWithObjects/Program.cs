using System.Reflection.Metadata.Ecma335;
using static System.Console;

ForegroundColor = ConsoleColor.Yellow;

string[] names = new[] { "Michael" , "Pam", "Jim", "Dwight", "Angela", "Kevin", "Toby", "Creed" };
Write ("Original:");
foreach (string item in names) Write ($" {item}");
WriteLine ();

WriteLine ("== Deferred execution");

var query1 = names.Where (name => name.EndsWith ("m"));
string[] result = query1.ToArray ();

Write ("- query: ");
foreach (string name in query1)
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
foreach (string name in query1)
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

ForegroundColor = ConsoleColor.Cyan;
Write ("Performed Where:");
//var query = names.Where (new Func<string, bool> (NameLongerThanFour));
//var query = names.Where (NameLongerThanFour);
var query = names.Where (name => name.Length > 4);
foreach (string item in query) Write ($" {item}");
WriteLine();

Write ("Performed Where & OrderBy:");
query = names.Where (name => name.Length > 4).OrderBy(name => name.Length);
foreach (string item in query) Write ($" {item}");
WriteLine ();

Write ("Performed Where & Descend:");
query = names.Where (name => name.Length > 4).OrderByDescending (name => name.Length);
foreach (string item in query) Write ($" {item}");
WriteLine ();

Write ("Performed Where & ThenBy:");
query = names.Where (name => name.Length > 4).OrderBy (name => name.Length).ThenBy(name => name);
foreach (string item in query) Write ($" {item}");
WriteLine ();

ForegroundColor = ConsoleColor.DarkYellow;

WriteLine ("Filtering by type");
List<Exception> exceptions = new ()
{
    new ArgumentException(),
    new SystemException(),
    new IndexOutOfRangeException(),
    new InvalidOperationException(),
    new NullReferenceException(),
    new InvalidCastException(),
    new OverflowException(),
    new DivideByZeroException(),
    new ApplicationException()
};

IEnumerable<ArithmeticException> arithmeticExceptionsQuery = exceptions.OfType<ArithmeticException> ();
foreach(ArithmeticException exception in arithmeticExceptionsQuery)
    Console.WriteLine(exception);

ResetColor ();

//static bool NameLongerThanFour(string name)
//{
//    return name.Length > 4;
//}
