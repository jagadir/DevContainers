using Microsoft.AspNetCore.Mvc;

namespace DemoApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private static readonly Product[] Products = new[]
    {
        new Product { Id = 1, Name = "Product 1", Price = 100 },
        new Product { Id = 2, Name = "Product 2", Price = 200 },
        new Product { Id = 3, Name = "Product 3", Price = 300 },
        new Product { Id = 4, Name = "Product 4", Price = 400 },
        new Product { Id = 5, Name = "Product 5", Price = 500 },
    };  

    private readonly ILogger<ProductController> _logger;

    public ProductController(ILogger<ProductController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetProducts")]
    public IEnumerable<Product> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new Product
        {
            Id = index,
            Name = $"Product {index}",
            Price = index * 100
        }
       )
        .ToArray();
    }
}
