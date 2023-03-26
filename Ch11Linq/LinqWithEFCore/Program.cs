using System.Xml.Linq;
using Microsoft.EntityFrameworkCore;

using Packt.Shared;

using static System.Console;

ForegroundColor = ConsoleColor.Yellow; FilterAndSort();
ForegroundColor = ConsoleColor.Cyan;JoinCategoriesAndProducts();
ForegroundColor = ConsoleColor.DarkYellow; GroupJoinCategoriedAndProducts();
ForegroundColor = ConsoleColor.DarkCyan; CustomExtensionMethods();
ForegroundColor = ConsoleColor.Green; OutputProductsAsXml();
ForegroundColor = ConsoleColor.Yellow; ProcessSettings();

ResetColor ();

static void FilterAndSort ()
{
    using Northwind db = new();
    DbSet<Product> allProducts = db.Products!;

    if(allProducts is null)
    {
        Console.WriteLine("No products found.");
        return;
    }
    IQueryable<Product> processedProducts = allProducts.ProcessSequence();

    //IQueryable<Product> filteredProducts = allProducts.Where (p => p.UnitPrice < 10M);
    IQueryable<Product> filteredProducts = processedProducts.Where(p => p.UnitPrice < 10M);
    IOrderedQueryable<Product> sortedAndFilteredProducts = filteredProducts.OrderByDescending(p => p.UnitPrice);

    //WriteLine("Products that cost less than $10:");
    //foreach(Product p in sortedAndFilteredProducts)
    //    WriteLine("{0}: {1} costs {2:$#.##0.00}", p.ProductId, p.ProductName, p.UnitPrice);
    //WriteLine();

    var projectedProducts = sortedAndFilteredProducts.Select (p => new
    {
        p.ProductId,
        p.ProductName,
        p.UnitPrice
    });

    WriteLine ("Products that cost less than $10:");
    foreach (var p in projectedProducts)
        WriteLine ("{0}: {1} costs {2:$#,##0.00}", p.ProductId, p.ProductName, p.UnitPrice);
    WriteLine ();
}

static void JoinCategoriesAndProducts ()
{
    using Northwind db = new ();
    var queryJoin = db.Categories?.Join (
        inner: db.Products!,
        outerKeySelector: category => category.CategoryId,
        innerKeySelector: product => product.CategoryId,
        resultSelector: (c, p) => new {
            c.CategoryName, p.ProductName, p.ProductId
        })
        .OrderBy(cp => cp.CategoryName);

    foreach (var item in queryJoin!)
        WriteLine ("{0}: {1} is in {2}.",
            arg0: item.ProductId, arg1: item.ProductName, arg2: item.CategoryName);
}

static void GroupJoinCategoriedAndProducts ()
{
    using Northwind db = new ();
    var queryGroup = db.Categories?.AsEnumerable ().GroupJoin (
        inner: db.Products!,
        outerKeySelector: category => category.CategoryId,
        innerKeySelector: product => product.CategoryId,
        resultSelector: (c, matchingProducts) => new
        {
            c.CategoryName,
            Products = matchingProducts.OrderBy (p => p.ProductName)
        });

    foreach (var category in queryGroup!)
    {
        WriteLine ("{0} has {1} products.",
            arg0: category.CategoryName, arg1: category.Products.Count ());
        foreach (var product in category.Products)
            WriteLine ($" {product.ProductName}");
    }
}

static void CustomExtensionMethods()
{
    using Northwind db = new();
    WriteLine("Mean units in stock: {0:N0}", db.Products?.Average(p => p.UnitsInStock));
    WriteLine("Mean unit price: {0:$#,##0.00}", db.Products?.Average(p => p.UnitPrice));
    WriteLine("Median units in stock: {0:N0}", db.Products?.Median(p => p.UnitPrice));
    WriteLine("Median unit price: {0:$#,##0.00}", db.Products?.Median(p => p.UnitPrice));
    WriteLine("Mode units in stock: {0:N0}", db.Products?.Mode(p => p.UnitsInStock));
    WriteLine("Mode unit price: {0:$#,##0.00}", db.Products?.Mode(p => p.UnitPrice));
}

static void OutputProductsAsXml()
{
    using Northwind db = new();

    Product[]? productsArray = db.Products?.ToArray();
    XElement xml = new("products",
        from p in productsArray
        select new XElement("products",
        new XAttribute("id", p.ProductId),
        new XAttribute("price", p.UnitPrice!),
        new XAttribute("name", p.ProductName)));
    Console.WriteLine(xml.ToString());
}

static void ProcessSettings()
{
    XDocument doc = XDocument.Load("settings.xml");
    var appSettings = doc.Descendants("appSettings")
        .Descendants("add")
        .Select(node => new
        {
            Key = node.Attribute("key")?.Value,
            Value = node.Attribute("value")?.Value
        }).ToArray();
    foreach(var item in appSettings)
        Console.WriteLine($"{item.Key}: {item.Value}");
}
