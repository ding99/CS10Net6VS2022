using Microsoft.EntityFrameworkCore; // DbContext, DbSet<T>

namespace Packt.Shared;

public class Northwind : DbContext
{
    public DbSet<Category>? Categories { get; set; }
    public DbSet<Product>? Products { get; set; }
    protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
    {
        string path = Path.Combine (Environment.CurrentDirectory, "Northwind.db");
        optionsBuilder.UseSqlite($"Filename={path}");

        //string connection = "Data Source=.'" +
        //"Initial Catalog=Northwind;" +
        //"Integrated Security=true;" +
        //"MultipleActiveResultSets=true;";
        //optionsBuilder.UseSqlite(connection);
    }

    protected override void OnModelCreating (ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product> ()
            .Property (product => product.UnitPrice)
            .HasConversion<double> ();
    }
}
