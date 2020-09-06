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
  public class OrderItemsController : ControllerBase
  {
    private readonly IRepository<OrderItem> _repository;

    public OrderItemsController(IRepository<OrderItem> repository)
    {
      _repository = repository;
    }

    // GET: api/OrderItems
    [HttpGet]
    public async Task<ActionResult<IEnumerable<OrderItem>>> GetOrderItems()
    {
      return Ok(await _repository.GetAll());
    }

    // GET: api/OrderItems/5
    [HttpGet("{id}")]
    public async Task<ActionResult<OrderItem>> GetOrderItem(int id)
    {
      var orderItem = await _repository.GetById(id);

      if (orderItem == null)
      {
        return NotFound();
      }

      return orderItem;
    }

    // PUT: api/OrderItems/5
    // To protect from overposting attacks, enable the specific properties you want to bind to, for
    // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
    [HttpPut("{id}")]
    public async Task<IActionResult> PutOrderItem(int id, OrderItem orderItem)
    {
      if (id != orderItem.ProductId)
      {
        return BadRequest();
      }

      _repository.Update(orderItem);

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

    // POST: api/OrderItems
    // To protect from overposting attacks, enable the specific properties you want to bind to, for
    // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
    [HttpPost]
    public async Task<ActionResult<OrderItem>> PostOrderItem(OrderItem orderItem)
    {
      _repository.Create(orderItem);
      try
      {
        await _repository.SaveChanges();
      }
      catch (DbUpdateException)
      {
        if (_repository.Exists(orderItem.ProductId))
        {
          return Conflict();
        }
        else
        {
          throw;
        }
      }

      return CreatedAtAction("GetOrderItem", new {id = orderItem.ProductId}, orderItem);
    }

    // DELETE: api/OrderItems/5
    [HttpDelete("{id}")]
    public async Task<ActionResult<OrderItem>> DeleteOrderItem(int id)
    {
      var orderItem = await _repository.GetById(id);
      if (orderItem == null)
      {
        return NotFound();
      }

      _repository.Delete(orderItem);
      await _repository.SaveChanges();

      return orderItem;
    }
  }
}
