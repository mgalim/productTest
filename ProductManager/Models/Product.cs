namespace ProductManager.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public ProductCategory Category { get; set; }

    public Product(int id, string name, decimal price, ProductCategory category)
    {
        if (price < 0)
            throw new ArgumentException("El precio no puede ser negativo.");

        Id = id;
        Name = name;
        Price = price;
        Category = category;
    }
}
