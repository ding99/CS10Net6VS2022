using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore;  // Include extension method
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore.ChangeTracking;

using Packt.Shared;

using static System.Console;
using Packt.SHared;
using Microsoft.EntityFrameworkCore.Update;

WriteLine ($"Using {ProjectConstants.DatabaseProvider} database provider.");

ForegroundColor = ConsoleColor.Yellow; QueryingCategories ();
ForegroundColor = ConsoleColor.Cyan; FilteredInclude ();
ForegroundColor = ConsoleColor.DarkYellow; QueryingProducts ();
ForegroundColor = ConsoleColor.Green; QueryingWithLike ();

ForegroundColor = ConsoleColor.DarkCyan;
WriteLine ("-- Insert an entity");
if (AddProduct (categoryId: 6, productName: "Bob's Burgers", price: 500M))
    WriteLine ("Add product successful.");
ListProducts ();
ForegroundColor = ConsoleColor.Cyan;
WriteLine ("-- Increase price");
if(IncreaseProductPrice(productNameStartsWith:"Bob", amount: 20M))
    WriteLine("Update product price successful.");
ListProducts ();
ForegroundColor = ConsoleColor.DarkCyan;
WriteLine ("-- Delete an entity");
int deleted = DeleteProducts (productNameStartsWith: "Bob");
WriteLine($"{deleted} product(s) were deleted.");
ListProducts ();

ResetColor ();

static void QueryingCategories ()
{
    using Northwind db = new ();

    ILoggerFactory loggerFactory = db.GetService<ILoggerFactory> ();
    loggerFactory.AddProvider (new ConsoleLoggerProvider ());

    WriteLine ("Categories and how many products they have:");
    IQueryable<Category>? categories; // = db.Categories;//?.Include (c => c.Products);
    db.ChangeTracker.LazyLoadingEnabled = false;
    Write ("Enable eager loading? (Y/N):");
    bool eagerloading = false;// (ReadKey ().Key == ConsoleKey.Y);
    bool explicitloading = false;
    WriteLine();

    if (eagerloading)
        categories = db.Categories?.Include (c => c.Products);
    else
    {
        categories = db.Categories;
        Write ("Enable explicit loading? (Y/N):");
        explicitloading = true; // (ReadKey().Key == ConsoleKey.Y);
        WriteLine();
    }

    if (categories is null)
    {
        WriteLine("No categories found.");
        return;
    }
    int n = 0;
    foreach (Category c in categories)
    {
        WriteLine ($"Explicitly load products for {c.CategoryName}? (Y/N):");
        ConsoleKeyInfo key = (n++ % 3) == 0 ? new ConsoleKeyInfo((char)ConsoleKey.Y, ConsoleKey.Y, false, false, false) : new ConsoleKeyInfo ((char)ConsoleKey.N, ConsoleKey.N, false, false, false);//  ReadKey ();

        if (key.Key == ConsoleKey.Y)
        {
            CollectionEntry<Category, Product> products = db.Entry (c).Collection (c2 => c2.Products);
            if (!products.IsLoaded) products.Load ();
        }
        WriteLine ($"{c.CategoryName} has {c.Products.Count} products.");
    }
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
        .TagWith("Products filtered by price and sorted.")
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

static void QueryingWithLike ()
{
    using Northwind db = new ();

    ILoggerFactory factory = db.GetService<ILoggerFactory> ();
    factory.AddProvider (new ConsoleLoggerProvider ());
    
    WriteLine ("Enter part of a product name:(che)");
    string? input = "che"; //ReadLine();
    IQueryable<Product>? products = db.Products?.Where (p => EF.Functions.Like (p.ProductName, $"%{input}%"));

    if(products is null)
    {
        WriteLine("No products found.");
        return;
    }
    
    foreach(Product p in products)
        WriteLine("{0} has {1} units in stock. Discontinued? {2}", p.ProductName, p.Stock, p.Discontinued);
}

static bool AddProduct(int categoryId, string productName, decimal? price)
{
    using Northwind db = new ();
    Product p = new ()
    {
        CategoryId = categoryId,
        ProductName = productName,
        Cost = price
    };
    db.Products?.Add (p);
    int affected = db.SaveChanges ();
    return (affected == 1);
}

static void ListProducts ()
{
    using Northwind db = new ();
    WriteLine ("{0,-3} {1,-35} {2,8} {3,5} {4} (count:{5})",
        "Id", "Product Name", "Cost", "Stock", "Disc.", db.Products?.Count());
    foreach (Product p in db.Products.OrderByDescending (product => product.Cost))
        WriteLine ("{0:000} {1,-35}, {2,8:$#,##0.00} {3,5} {4}",
            p.ProductId, p.ProductName, p.Cost, p.Stock, p.Discontinued);
}

static bool IncreaseProductPrice(string productNameStartsWith, decimal amount)
{
    using Northwind db = new ();
    Product updateProduct = db.Products.First (p => p.ProductName.StartsWith(productNameStartsWith));
    updateProduct.Cost += amount;
    int affected = db.SaveChanges ();
    return (affected == 1);
}

static int DeleteProducts(string productNameStartsWith)
{
    using Northwind db = new ();
    IQueryable<Product>? products = db.Products?.Where(
        p => p.ProductName.StartsWith(productNameStartsWith));
    if(products is null)
    {
        Console.WriteLine ("No products found to delete.");
        return 0;
    }
    else
        db.Products?.RemoveRange (products);
    int affected = db.SaveChanges ();
    return affected;
}
