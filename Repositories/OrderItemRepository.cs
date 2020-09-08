using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SimpleShop.Models;

namespace SimpleShop.Repositories
{
  public class OrderItemRepository:IRepository<OrderItem>
  {
    private readonly ShopContext _context;

    public OrderItemRepository(ShopContext context)
    {
      _context = context;
    }

    public async Task<int> SaveChanges()
    {
      return await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<OrderItem>> GetAll()
    {
      return await _context.OrderItems.Include(item => item.Product).ToListAsync();
    }

    public async Task<OrderItem> GetById(int id)
    {
      return await _context.OrderItems.FindAsync(id);
    }

    public void Create(OrderItem value)
    {
      _context.OrderItems.Add(value);
    }

    public void Update(OrderItem value)
    {
      _context.Entry(value).State = EntityState.Modified;
    }

    public void Delete(OrderItem value)
    {
      _context.OrderItems.Remove(value);
    }

    public bool Exists(int id)
    {
      return _context.OrderItems.Any(e => e.ProductId == id);
    }

  }
}
