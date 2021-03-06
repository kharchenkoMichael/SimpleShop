﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleShop.Models
{
  public class ProductCategory
  {
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    public List<Product> Products { get; set; }

    public ProductCategory()
    {
      Products = new List<Product>();
    }
  }
}
