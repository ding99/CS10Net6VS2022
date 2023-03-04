﻿using Microsoft.EntityFrameworkCore; //DbContext, DbContextOptionsBuilder

using static System.Console;

namespace Packt.Shared;

public class Northwind : DbContext
{
    protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
    {
        if (ProjectConstants.DatabaseProvider == "SQLite")
        {
            string path = Path.Combine (Environment.CurrentDirectory, "Northwind.db");
            Console.WriteLine($"Using {path} database file.");
            optionsBuilder.UseSqlite ($"Filename = {path}");
        }
        else
        {
            string connection = "Data Source=.;" + "Initial Catalog=Northwind;" + "Integrated Security=true;" + "MultipleActiveResultSets=true;";
            optionsBuilder.UseSqlServer(connection);
        }
    }
}
