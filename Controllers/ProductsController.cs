using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class ProductsController : ControllerBase
{
    // Produtos mockados
    private static readonly List<Product> Products = new()
    {
        new Product { Id = 1, Title = "Geladeira Frost Free", Description = "350L", Price = 1500.0, ImageUrl = "https://imgs.casasbahia.com.br/55066470/1g.jpg" },
        new Product { Id = 2, Title = "Smartphone Galaxy", Description = "128GB", Price = 1200.0, ImageUrl = "https://imgs.casasbahia.com.br/55066185/1g.jpg" },
        new Product { Id = 3, Title = "Notebook Dell", Description = "16GB RAM", Price = 4500.0, ImageUrl = "https://imgs.casasbahia.com.br/1546366805/1xg.jpg" }
    };

    // Endpoint para buscar produtos
    [HttpGet]
    public IActionResult GetProducts([FromQuery] string? q)
    {
        var searchTerm = q?.ToLower() ?? string.Empty;
        var filteredProducts = Products
            .Where(product => product.Title.ToLower().Contains(searchTerm))
            .ToList();

        return Ok(filteredProducts);
    }
}

// Classe para representar produtos
public class Product
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public double Price { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
}
