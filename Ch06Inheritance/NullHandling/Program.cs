using static System.Console;

ForegroundColor = ConsoleColor.Yellow;

int thisCannotBeNull = 4;
//thisCannotBeNull = null;
int? thisCouldBeNull = null;
WriteLine($"null: [{thisCouldBeNull}]");
WriteLine($"null default: [{thisCouldBeNull.GetValueOrDefault()}]");
thisCouldBeNull = 7;
WriteLine($"7: [{thisCouldBeNull}]");
WriteLine($"7 default: [{thisCouldBeNull.GetValueOrDefault()}]");

ForegroundColor = ConsoleColor.Cyan;
Address address = new();
address.Building = null;
//address.Street = null;
address.City = "London";
//address.Region = null;

class Address
{
    public string? Building;
    public string Street = string.Empty;
    public string City = string.Empty;
    public string Region = string.Empty;
}
