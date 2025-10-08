// Controllers/ProductsController.cs
using BestPracticeApi.Data;
using BestPracticeApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BestPracticeApi.Controllers;

[ApiController]
[Route("api/[controller]")] // URL: /api/products
public class ProductsController : ControllerBase
{
    private readonly AppDbContext _context;

    public ProductsController(AppDbContext context)
    {
        _context = context;
    }

    // GET: /api/products
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
    {
        return await _context.Products.ToListAsync();
    }

    // GET: /api/products/id
    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetProduct(int id)
    {
        var product = await _context.Products.FindAsync(id);

        if (product == null)
        {
            return NotFound(); 
        }

        return Ok(product); 
    }

    // POST: /api/products
    [HttpPost]
    public async Task<ActionResult<Product>> CreateProduct([FromBody] CreateProductDto productDto)
    {
        var product = new Product
        {
            Name = productDto.Name,
            Price = productDto.Price,
            CreateDate = DateTime.UtcNow
        };

        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
    }

    // PUT: /api/products/5
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProduct(int id, [FromBody] UpdateProductDto productDto)
    {
        var productToUpdate = await _context.Products.FindAsync(id);

        if (productToUpdate == null)
        {
            return NotFound();
        }

        productToUpdate.Name = productDto.Name;
        productToUpdate.Price = productDto.Price;

        await _context.SaveChangesAsync();

        return NoContent(); 
    }

    // DELETE: /api/products/id
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        var productToDelete = await _context.Products.FindAsync(id);

        if (productToDelete == null)
        {
            return NotFound();
        }

        _context.Products.Remove(productToDelete);
        await _context.SaveChangesAsync();

        return NoContent(); 
    }
}