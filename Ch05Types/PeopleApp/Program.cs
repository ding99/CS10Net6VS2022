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

Console.ResetColor ();