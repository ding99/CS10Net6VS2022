using Packt.Shared;

Console.ForegroundColor = ConsoleColor.Yellow;

var bob = new Person
{
    Name = "Bob Smith",
    DateOfBirth = new DateTime (1966, 3, 7),
    FavoriteAncientWonder = WondersOfTheAncientWorld.StatueOfZeusAtOlympia,
    BucketList = WondersOfTheAncientWorld.HangingGardensOfBabylon | WondersOfTheAncientWorld.MausoleumAtHalicarnassus
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

Console.WriteLine($"{bob.Name} was born on {bob.HomePlanet}");

Console.WriteLine ("{0}'s favorite wonder is {1}. Its integer is {2}.",
    bob.Name,
    bob.FavoriteAncientWonder,
    (int)bob.FavoriteAncientWonder);

Console.WriteLine ($"{bob.Name}'s bucket list is {bob.BucketList}");

bob.Children.Add(new Person { Name = "Alfred" });
bob.Children.Add(new Person { Name = "Zoe" });
Console.WriteLine($"{bob.Name} has {bob.Children.Count} children:");
for(int idx = 0; idx < bob.Children.Count; idx++)
{
    Console.WriteLine($"  {bob.Children[idx].Name}");
}

BankAccount.InterestRate = 0.012M;

var jonesAccount = new BankAccount
{
    AccountName = "Mrs.Jones",
    Balance = 2400
};
Console.WriteLine("{0} earned {1:C} interest.", jonesAccount.AccountName, jonesAccount.Balance * BankAccount.InterestRate);

var gerrierAccount = new BankAccount
{
    AccountName = "Ms.Gerrier",
    Balance = 98
};
Console.WriteLine("{0} earned {1:C} interest.", gerrierAccount.AccountName, gerrierAccount.Balance * BankAccount.InterestRate);

Console.WriteLine($"{bob.Name} is a {Person.Species}.");
Console.WriteLine($"MaxValue Int32 is {Int32.MaxValue}. PI is {Math.PI}");

Console.ForegroundColor = ConsoleColor.Cyan;
var blankPerson = new Person();
Console.WriteLine("{0} of {1} was created at {2:hh:mm:ss} on a {2:dddd}.",
    blankPerson.Name,
    blankPerson.HomePlanet,
    blankPerson.Instantiated
);
var gunny = new Person(initialName: "Gunny", homePlanet: "Mars");
Console.WriteLine("{0} of {1} was created at {2:hh:mm:ss} on a {2:dddd}.",
    gunny.Name,
    gunny.HomePlanet,
    gunny.Instantiated
);

Console.ForegroundColor = ConsoleColor.Green;
bob.WriteToConsole();
Console.WriteLine(bob.GetOrigin());
(string, int)fruit = bob.GetFruit();
Console.WriteLine($"{fruit.Item1}, {fruit.Item2} there are.");
var fruitNamed = bob.GetNamedFruit();
Console.WriteLine($"There are {fruitNamed.Number} {fruitNamed.Name}");
(var fruitName, var fruitNumber) = bob.GetFruit();
Console.WriteLine($"Deconstructed: {fruitName}, {fruitNumber}");

var (name1, dob1) = bob;
Console.WriteLine($"Deconstructed: {name1}, {dob1}");
var (name2, dob2, fav2) = bob;
Console.WriteLine($"Deconstructed: {name2}, {dob2}, {fav2}");

Console.ForegroundColor = ConsoleColor.DarkYellow;
Console.WriteLine(bob.SayHello());
Console.WriteLine(bob.SayHello("Emily"));

Console.WriteLine(bob.OptionalParameters());
Console.WriteLine(bob.OptionalParameters("Jump!", 98.5));
Console.WriteLine(bob.OptionalParameters(number:30.7, command:"Hide!"));
Console.WriteLine(bob.OptionalParameters("Poke!", active: false));

Console.ForegroundColor = ConsoleColor.DarkCyan;
int a = 10, b = 20, c = 30;
Console.WriteLine($"Before: a={a}, b={b}, c={c}");
bob.PassingParameters(a, ref b, out c);
Console.WriteLine($"After:  a={a}, b={b}, c={c}");
int d = 10, e = 20;
Console.WriteLine($"Before: d={d}, e={e}, f doesn't exist yet!");
bob.PassingParameters(d, ref e, out int f);
Console.WriteLine($"After:  d={d}, e={e}, f={f}");
bob.ShowPartial();

Console.ForegroundColor = ConsoleColor.Yellow;
Person sam = new()
{
    Name = "Sam",
    DateOfBirth = new(1972, 1, 27)
};
Console.WriteLine(sam.Origin);
Console.WriteLine(sam.Greeting);
Console.WriteLine(sam.Age);

sam.FavoriteIceCream = "Chocoloate Fudge";
Console.WriteLine($"Sam's favorite ice-cream flavor is {sam.FavoriteIceCream}.");
sam.FavoritePrimaryColor = "Red";
Console.WriteLine($"Sam's favorite primary color is {sam.FavoritePrimaryColor}.");
try
{
    sam.FavoritePrimaryColor = "cyan";
    Console.WriteLine($"Sam's favorite primary color is {sam.FavoritePrimaryColor}.");
}
catch(Exception ex)
{
    Console.WriteLine(ex.Message);
}

Console.ForegroundColor = ConsoleColor.Cyan;
sam.Children.Add(new() { Name = "Charlie" });
sam.Children.Add(new() { Name = "Ella" });
Console.WriteLine($"Sam's first child is {sam.Children[0].Name}");
Console.WriteLine($"Sam's second child is {sam.Children[1].Name}");
Console.WriteLine($"Sam's first child is {sam[0].Name}");
Console.WriteLine($"Sam's second child is {sam[1].Name}");

Console.ForegroundColor = ConsoleColor.Green;
object[] passengers =
{
    new FirstClassPassenger { AirMiles = 1_419},
    new FirstClassPassenger { AirMiles = 16_562},
    new BusinessClassPassenger(),
    new CoachClassPassenger{ CarryOnKG = 25.7 },
    new CoachClassPassenger{ CarryOnKG = 0 },
};
foreach(object passenger in passengers)
{
    decimal flightCost = passenger switch
    {
        /* C# 8 syntax
        FirstClassPassenger p when p.AirMiles > 35000 => 1500M,
        FirstClassPassenger p when p.AirMiles > 15000 => 1750M,
        FirstClassPassenger _ => 2000M, */
        //C# 9 or later syntax
        FirstClassPassenger p => p.AirMiles switch
        {
            > 35000 => 1500M,
            > 15000 => 1750M,
            _ => 2000M
        },
        BusinessClassPassenger _ => 1000M,
        CoachClassPassenger p when p.CarryOnKG < 10.0 => 500M,
        CoachClassPassenger _ => 650M,
        _ => 800M
    };
    Console.WriteLine($"Flight costs {flightCost:C} for {passenger}");
}

Console.ForegroundColor = ConsoleColor.DarkYellow;
ImmutablePerson jeff = new()
{
    FirstName = "Jeff",
    LastName = "Winger"
};
//jeff.FirstName = "Geoff"; // syntax error
ImmutableVehicle car = new()
{
    Brand = "Mazda MX-5 RF",
    Color = "Soul Red Crystal Metallic",
    Wheels = 4
};
ImmutableVehicle repaintedCar = car with { Color = "Polymetal Grey Metallic" };
Console.WriteLine($"Original car color was {car.Color}.");
Console.WriteLine($"New car color is {repaintedCar.Color}.");
ImmutableAnimal oscar = new("Oscar", "Labrador");
var (who, what) = oscar;
Console.WriteLine($"{who} is a {what}.");

Console.ResetColor ();