using static System.Console;

namespace Packt.Shared;

public class Person : object
{
    public string? Name;
    public DateTime DateOfBirth;
    public List<Person> Children = new();

    public void WriteToConsole()
    {
        WriteLine($"{Name} was born on a {DateOfBirth:dddd}.");
    }
}