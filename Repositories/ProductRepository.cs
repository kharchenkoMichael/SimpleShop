using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SimpleShop.Models;

namespace SimpleShop.Repositories
{
  public class ProductRepository: IProductRepository
  {
    private readonly ShopContext _context;

    public ProductRepository(ShopContext context)
    {
      _context = context;
    }

    public async Task<int> SaveChanges()
    {
      return await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Product>> GetAll()
    {
      return await _context.Products.ToListAsync();
    }

    public async Task<Product> GetById(int id)
    {
      return await _context.Products.FindAsync(id);
    }

    public void Create(Product value)
    {
      _context.Products.Add(value);
    }

    public void Update(Product value)
    {
      _context.Entry(value).State = EntityState.Modified;
    }

    public void Delete(Product value)
    {
      _context.Products.Remove(value);
    }
    public bool Exists(int id)
    {
      return _context.Products.Any(e => e.Id == id);
    }

    public async Task<IEnumerable<Product>> GetByCategoryId(int categoryId)
    {
      return await _context.Products.Where(item => item.ProductCategoryId == categoryId).ToListAsync();
    }
  }
}
