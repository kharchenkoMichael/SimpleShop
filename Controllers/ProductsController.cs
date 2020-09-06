using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleShop.Models;
using SimpleShop.Repositories;

namespace SimpleShop.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ProductsController : ControllerBase
  {
    private readonly IProductRepository _repository;

    public ProductsController(IProductRepository repository)
    {
      _repository = repository;
    }
    
    // GET: api/Products/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetProduct(int id)
    {
      var product = await _repository.GetById(id);

      if (product == null)
      {
        return NotFound();
      }

      return product;
    }

    // GET: api/Products/
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> GetProductsByCategory([FromQuery]int? categoryId)
    {
      return categoryId ==null 
        ? Ok(await _repository.GetAll()) : 
        Ok(await _repository.GetByCategoryId(categoryId.Value));
    }

    // PUT: api/Products/5
    // To protect from overposting attacks, enable the specific properties you want to bind to, for
    // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
    [HttpPut("{id}")]
    public async Task<IActionResult> PutProduct(int id, Product product)
    {
      if (id != product.Id)
      {
        return BadRequest();
      }

      _repository.Update(product);

      try
      {
        await _repository.SaveChanges();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!_repository.Exists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return NoContent();
    }

    // POST: api/Products
    // To protect from overposting attacks, enable the specific properties you want to bind to, for
    // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
    [HttpPost]
    public async Task<ActionResult<Product>> PostProduct(Product product)
    {
      _repository.Create(product);
      await _repository.SaveChanges();

      return CreatedAtAction("GetProduct", new {id = product.Id}, product);
    }

    // DELETE: api/Products/5
    [HttpDelete("{id}")]
    public async Task<ActionResult<Product>> DeleteProduct(int id)
    {
      var product = await _repository.GetById(id);
      if (product == null)
      {
        return NotFound();
      }

      _repository.Delete(product);
      await _repository.SaveChanges();

      return product;
    }
  }
}
