using Microsoft.EntityFrameworkCore;  // Include extension method
using Packt.Shared;

using static System.Console;

WriteLine($"Using {ProjectConstants.DatabaseProvider} database provider.");

ForegroundColor = ConsoleColor.Yellow; QueryingCategories ();
ForegroundColor = ConsoleColor.Cyan; FilteredInclude ();

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
        Console.WriteLine($"{c.CategoryName} has {c.Products.Count} products.");
}

static void FilteredInclude ()
{
    using Northwind db = new ();
    Console.WriteLine("Enter a mininim for units in stock: (100)");
    string unitsInStock = "100";  // ReadLine()
    int stock = int.Parse(unitsInStock);

    IQueryable<Category>? categories = db.Categories?.Include(c => c.Products.Where(p => p.Stock >= stock));
    if(categories is null)
    {
        Console.WriteLine("No categories found.");
        return;
    }
    foreach(Category c in categories)
    {
        Console.WriteLine($"{c.CategoryName} has {c.Products.Count} products with a minimum of {stock} units in stock.");
        foreach(Product p in c.Products)
            Console.WriteLine($" {p.ProductName} has {p.Stock} units in stock.");
    }

}
