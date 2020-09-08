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
    private readonly IRepository<OrderItem> _orderRepository;
    private readonly IRepository<Product> _productRepository;

    public OrderItemsController(IRepository<OrderItem> orderRepository, IProductRepository productRepository)
    {
      _orderRepository = orderRepository;
      _productRepository = productRepository;
    }

    // GET: api/OrderItems
    [HttpGet]
    public async Task<ActionResult<IEnumerable<OrderItem>>> GetOrderItems()
    {
      return Ok(await _orderRepository.GetAll());
    }

    // GET: api/OrderItems/5
    [HttpGet("{id}")]
    public async Task<ActionResult<OrderItem>> GetOrderItem(int id)
    {
      var orderItem = await _orderRepository.GetById(id);

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

      _orderRepository.Update(orderItem);

      try
      {
        await _orderRepository.SaveChanges();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!_orderRepository.Exists(id))
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
      _orderRepository.Create(orderItem);
      try
      {
        await _orderRepository.SaveChanges();
      }
      catch (DbUpdateException)
      {
        if (_orderRepository.Exists(orderItem.ProductId))
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
      var orderItem = await _orderRepository.GetById(id);
      if (orderItem == null)
      {
        return NotFound();
      }

      _orderRepository.Delete(orderItem);
      await _orderRepository.SaveChanges();

      return orderItem;
    }

    // DELETE: api/OrderItems
    [HttpDelete]
    public async Task<ActionResult> Delete()
    {
      var orderItems = await _orderRepository.GetAll();
      foreach (var orderItem in orderItems)
      {
        _orderRepository.Delete(orderItem);
        var product = orderItem.Product;

        if (product.NumberOfItemsInStock < orderItem.Count)
          return BadRequest();

        product.NumberOfItemsInStock -= orderItem.Count;
        _productRepository.Update(product);
      }

      await _productRepository.SaveChanges();
      await _orderRepository.SaveChanges();

      return Ok();
    }
  }
}
