﻿using System.ComponentModel.DataAnnotations.Schema;  // [Column]

namespace Packt.Shared;

public class Category
{
    public int CategoryId { get; set; }
    public string? CategeryName { get; set; }
    [Column(TypeName = "ntext")]
    public string? Description { get; set; }

    public virtual ICollection<Product> Products { get; set; }

    public Category ()
    {
        Products = new HashSet<Product> ();
    }
}
