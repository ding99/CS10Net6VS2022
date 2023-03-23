using Microsoft.EntityFrameworkCore;
using Packt.Shared;

using static System.Console;

ForegroundColor = ConsoleColor.Yellow; FilterAndSort ();


ResetColor ();

static void FilterAndSort ()
{
    using Northwind db = new ();
    DbSet<Product> allProducts = db.Products!;
    IQueryable<Product> filteredProducts = allProducts.Where (p => p.UnitPrice < 10M);
    IOrderedQueryable<Product> sortedAndFilteredProducts = filteredProducts.OrderByDescending(p => p.UnitPrice);

    Console.WriteLine("Products that cost less than $10:");
    foreach(Product p in sortedAndFilteredProducts)
        Console.WriteLine("{0}: {1} costs {2:$#.##0.00}", p.ProductId, p.ProductName, p.UnitPrice);
    Console.WriteLine();

    var projectedProducts = sortedAndFilteredProducts.Select (p => new
    {
        p.ProductId,
        p.ProductName,
        p.UnitPrice
    });

    Console.WriteLine ("Products that cost less than $10:");
    foreach (var p in projectedProducts)
        Console.WriteLine ("{0}: {1} costs {2:$#.##0.00}", p.ProductId, p.ProductName, p.UnitPrice);
    Console.WriteLine ();

}

