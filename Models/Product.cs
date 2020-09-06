using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleShop.Models
{
  public class Product
  {
    [Key]
    public int Id { get; set; }

    public int ProductCategoryId { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public double Price { get; set; }

    [Range(0, int.MaxValue)]
    public int NumberOfItemsInStock { get; set; }

    [ForeignKey("ProductCategoryId")]
    public ProductCategory ProductCategory { get; set; }
  }
}
