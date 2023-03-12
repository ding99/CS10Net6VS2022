using Microsoft.EntityFrameworkCore;  // Include extension method
using Packt.Shared;

using static System.Console;

ForegroundColor = ConsoleColor.Yellow;

WriteLine($"Using {ProjectConstants.DatabaseProvider} database provider.");
QueryingCategories ();

ResetColor ();

static void QueryingCategories ()
{
    using Northwind db = new ();
    WriteLine("Categories and how many products they have:");
    IQueryable<Category>? categories = db.Categories?.Include (c => c.Products);
    if(categories is null)
    {
        Console.WriteLine("No categories found.");
        return;
    }
    foreach(Category c in categories)
    {
        Console.WriteLine($"{c.CategoryName} has {c.Products.Count} products.");
    }
}
