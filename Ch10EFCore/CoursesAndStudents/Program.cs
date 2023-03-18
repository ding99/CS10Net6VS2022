using Microsoft.EntityFrameworkCore;  // for GenerateCreateScript()
using CoursesAndStudents;  // Academy

using static System.Console;

ForegroundColor = ConsoleColor.Yellow;

using Academy a = new ();
bool deleted = await a.Database.EnsureDeletedAsync ();
WriteLine($"Database deleted: {deleted}");
bool created = await a.Database.EnsureCreatedAsync ();
WriteLine ($"Database created: {created}");

WriteLine("SQL script used to created database:");
WriteLine(a.Database.GenerateCreateScript());

foreach(Student s in a.Students!.Include(s => s.Courses))
{
    Console.WriteLine("{0} {1} attends the following {2} courses:",
        s.FirstName, s.LastName, s.Courses!.Count);
    foreach (Course c in s.Courses) Console.WriteLine ($" {c.Title}");
}

ResetColor ();

