using Packt.Shared;

Console.ForegroundColor = ConsoleColor.Yellow;

var bob = new Person
{
    Name = "Bob Smith",
    DateOfBirth = new DateTime (1966, 3, 7),
    FavoriteAncientWonder = WondersOfTheAncientWorld.StatueOfZeusAtOlympia
};

Console.WriteLine ("{0} was born on {1}",
    arg0: bob.Name,
    arg1: bob.DateOfBirth);
Console.WriteLine("{0} was born on {1:dddd, d MMMM yyyy}",
    arg0:bob.Name,
    arg1:bob.DateOfBirth);
Console.WriteLine ("{0} was born on {1:dd MMM yy}",
    arg0: bob.Name,
    arg1: bob.DateOfBirth);
Console.WriteLine ("{0} was born on {1:d MM yy}",
    arg0: bob.Name,
    arg1: bob.DateOfBirth);

Console.WriteLine ("{0}'s favorite wonder is {1}. Its integer is {2}.",
    bob.Name,
    bob.FavoriteAncientWonder,
    (int)bob.FavoriteAncientWonder);

Console.ResetColor ();