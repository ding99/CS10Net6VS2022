using static System.Console;

namespace Packt.Shared;

public class Person : object
{
    #region variables

    public string? Name;
    public DateTime DateOfBirth;
    public List<Person> Children = new();

    #endregion variables

    #region static methods

    public static Person Procreate(Person p1, Person p2)
    {
        Person baby = new()
        {
            Name = $"Baby of {p1.Name} and {p2.Name}"
        };
        p1.Children.Add(baby);
        p2.Children.Add(baby);
        return baby;
    }

    public static Person operator *(Person p1, Person p2)
    {
        return Person.Procreate(p1, p2);
    }

    public static int Factorial(int number)
    {
        if(number < 0)
        {
            throw new ArgumentException($"{nameof(number)} cannot be less than zero.");
        }
        return localFactorial(number);

        int localFactorial(int localNumber)
        {
            if(localNumber < 1) return 1;
            return localNumber * localFactorial(localNumber - 1);
        }
    }

    #endregion static methods

    #region instance methods

    public void WriteToConsole()
    {
        WriteLine($"{Name} was born on a {DateOfBirth:dddd}.");
    }

    public Person ProcreateWith(Person partner)
    {
        return Procreate(this, partner);
    }

    #endregion methods

}