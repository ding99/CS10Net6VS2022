using System.Globalization;

using static System.Console;

ForegroundColor = ConsoleColor.Yellow;

CultureInfo globalization = CultureInfo.CurrentCulture;
WriteLine("The current globalization cuture is {0}: {1}",
    globalization.Name, globalization.DisplayName);

CultureInfo localization = CultureInfo.CurrentUICulture;
WriteLine("The current localization cuture is {0}: {1}",
    localization.Name, localization.DisplayName);

WriteLine();

WriteLine("en-US: English (United States)");
WriteLine("da-DK: Danish (Denmark)");
WriteLine("fr-CA: French (Canada)");
Write("Enter an ISO culture code:");
string? newCulture = ReadLine();

if(!string.IsNullOrEmpty(newCulture))
{
    CultureInfo ci = new(newCulture);
    CultureInfo.CurrentCulture = ci;
    CultureInfo.CurrentUICulture = ci;
}
WriteLine();
Write("Enter your name: ");
string? name = ReadLine();
Write("Enter your date of birth: ");
string? dob = ReadLine();
Write("Enter your salary: ");
string? salary = ReadLine();
DateTime date = DateTime.Parse(dob);
int minutes = (int)DateTime.Today.Subtract(date).TotalMinutes;
decimal earns = decimal.Parse(salary);
WriteLine("{0} was born on a {1:dddd}, is {2:N0} minute old, and earns {3:C}", name, date, minutes, earns);

ResetColor();
