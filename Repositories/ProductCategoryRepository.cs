using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SimpleShop.Models;

namespace SimpleShop.Repositories
{
  public class ProductCategoryRepository:IRepository<ProductCategory>
  {
    private readonly ShopContext _context;

    public ProductCategoryRepository(ShopContext context)
    {
      _context = context;
    }

    public async Task<int> SaveChanges()
    {
      return await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<ProductCategory>> GetAll()
    {
      return await _context.ProductCategories.ToListAsync();
    }

    public async Task<ProductCategory> GetById(int id)
    {
      return await _context.ProductCategories.FindAsync(id);
    }

    public void Create(ProductCategory value)
    {
      _context.ProductCategories.Add(value);
    }

    public void Update(ProductCategory value)
    {
      _context.Entry(value).State = EntityState.Modified;
    }

    public void Delete(ProductCategory value)
    {
      _context.ProductCategories.Remove(value);
    }
    public bool Exists(int id)
    {
      return _context.ProductCategories.Any(e => e.Id == id);
    }
  }
}
