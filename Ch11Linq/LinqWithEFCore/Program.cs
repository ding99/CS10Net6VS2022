using Microsoft.EntityFrameworkCore;
using Packt.Shared;

using static System.Console;

ForegroundColor = ConsoleColor.Yellow;


ResetColor ();

static void FilterAndSort ()
{
    using Northwind db = new ();
    DbSet<Product> allProducts = db.Products;
}

