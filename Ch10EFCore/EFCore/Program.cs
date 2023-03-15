using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore;  // Include extension method
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using Packt.Shared;

using static System.Console;
using Packt.SHared;

WriteLine ($"Using {ProjectConstants.DatabaseProvider} database provider.");

ForegroundColor = ConsoleColor.Yellow; QueryingCategories ();
ForegroundColor = ConsoleColor.Cyan; FilteredInclude ();
ForegroundColor = ConsoleColor.DarkYellow; QueryingProducts ();

ResetColor ();

static void QueryingCategories ()
{
    using Northwind db = new ();

    ILoggerFactory loggerFactory = db.GetService<ILoggerFactory> ();
    loggerFactory.AddProvider (new ConsoleLoggerProvider ());

    WriteLine ("Categories and how many products they have:");
    IQueryable<Category>? categories = db.Categories?.Include (c => c.Products);
    if(categories is null)
    {
        WriteLine("No categories found.");
        return;
    }
    foreach(Category c in categories)
        WriteLine($"{c.CategoryName} has {c.Products.Count} products.");
}

static void FilteredInclude ()
{
    using Northwind db = new ();
    string mount = "99";

    WriteLine($"Enter a mininim for units in stock: ({mount})");
    string unitsInStock = mount; // "100";  // ReadLine()
    int stock = int.Parse(unitsInStock);

    IQueryable<Category>? categories = db.Categories?.Include(c => c.Products.Where(p => p.Stock >= stock));
    if(categories is null)
    {
        WriteLine("No categories found.");
        return;
    }

    WriteLine($"ToQueryString: {categories.ToQueryString()}");
    foreach (Category c in categories)
    {
        WriteLine($"{c.CategoryName} has {c.Products.Count} products with a minimum of {stock} units in stock.");
        foreach(Product p in c.Products)
            WriteLine($" {p.ProductName} has {p.Stock} units in stock.");
    }
}

static void QueryingProducts ()
{
    using Northwind db = new ();

    ILoggerFactory loggerFactory = db.GetService<ILoggerFactory> ();
    loggerFactory.AddProvider (new ConsoleLoggerProvider ());

    WriteLine("Products that const more than a price, highter at top.");
    string? input;
    decimal price;
    do
    {
        WriteLine("Enter a product price:");
        input = "50";  // input = ReadLine ();
    } while (!decimal.TryParse(input, out price));

    IQueryable<Product>? products = db.Products?
        .Where(product => product.Cost > price)
        .OrderByDescending(product => product.Cost);
    if(products is null)
    {
        WriteLine("No products found.");
        return;
    }
    foreach(Product p in products)
        WriteLine("{0}: {1} costs {2:$#.##0.00} and has {3} in stock.",
            p.ProductId, p.ProductName, p.Cost, p.Stock);
}
