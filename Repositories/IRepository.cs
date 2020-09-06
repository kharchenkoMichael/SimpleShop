using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleShop.Repositories
{
  public interface IRepository<T>
  {
    Task<int> SaveChanges();

    Task<IEnumerable<T>> GetAll();
    Task<T> GetById(int id);
    void Create(T value);
    void Update(T value);
    void Delete(T value);
    bool Exists(int id);
  }
}
