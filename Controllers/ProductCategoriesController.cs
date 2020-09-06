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
  public class ProductCategoriesController : ControllerBase
  {
    private readonly IRepository<ProductCategory> _repository;

    public ProductCategoriesController(IRepository<ProductCategory> repository)
    {
      _repository = repository;
    }

    // GET: api/ProductCategories
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductCategory>>> GetProductCategories()
    {
      return Ok(await _repository.GetAll());
    }

    // GET: api/ProductCategories/5
    [HttpGet("{id}")]
    public async Task<ActionResult<ProductCategory>> GetProductCategory(int id)
    {
      var productCategory = await _repository.GetById(id);

      if (productCategory == null)
      {
        return NotFound();
      }

      return productCategory;
    }

    // PUT: api/ProductCategories/5
    // To protect from overposting attacks, enable the specific properties you want to bind to, for
    // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
    [HttpPut("{id}")]
    public async Task<IActionResult> PutProductCategory(int id, ProductCategory productCategory)
    {
      if (id != productCategory.Id)
      {
        return BadRequest();
      }

      _repository.Update(productCategory);

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

    // POST: api/ProductCategories
    // To protect from overposting attacks, enable the specific properties you want to bind to, for
    // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
    [HttpPost]
    public async Task<ActionResult<ProductCategory>> PostProductCategory(ProductCategory productCategory)
    {
      _repository.Create(productCategory);
      await _repository.SaveChanges();

      return CreatedAtAction("GetProductCategory", new {id = productCategory.Id}, productCategory);
    }

    // DELETE: api/ProductCategories/5
    [HttpDelete("{id}")]
    public async Task<ActionResult<ProductCategory>> DeleteProductCategory(int id)
    {
      var productCategory = await _repository.GetById(id);
      if (productCategory == null)
      {
        return NotFound();
      }

      _repository.Delete(productCategory);
      await _repository.SaveChanges();

      return productCategory;
    }
  }
}
