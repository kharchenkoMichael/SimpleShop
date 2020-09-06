using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleShop.Models
{
  public class OrderItem
  {
    [Key]
    public int ProductId { get; set; }

    public int Count { get; set; }

    [ForeignKey("ProductId")]
    public Product Product { get; set; }
  }
}
