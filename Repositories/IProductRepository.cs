using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimpleShop.Models;

namespace SimpleShop.Repositories
{
  public interface IProductRepository: IRepository<Product>
  {
    Task<IEnumerable<Product>> GetByCategoryId(int categoryId);
  }
}
