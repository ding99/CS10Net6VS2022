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

Console.ResetColor ();