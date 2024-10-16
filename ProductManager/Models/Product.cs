namespace ProductManager.Models;

public class Product
{
    private string _name = string.Empty;
    private decimal _price;
    public int Id { get; set; }
    public string Name { get => _name; set => _name = ValidateName(value); }

    public decimal Price { get => _price; set => _price = ValidatePrice(value); }
    public ProductCategory Category { get; set; }

    public Product(int id, string name, decimal price, ProductCategory category)
    {
        Id = id;
        Name = name;
        Price = price;
        Category = category;
    }

    private static decimal ValidatePrice(decimal price)
    {
        if (price < 0)
            throw new ArgumentException("El precio no puede ser negativo.");
        return price;

    }

    private static string ValidateName(string name)
    {
        if (string.IsNullOrEmpty(name))
            throw new ArgumentException("El nombre no puede estar vacío.");

        return name.Trim();
    }

    public override string? ToString()
    {
        return $"\nID: {Id}\n" +
           $"Producto: {Name}\n" +
           $"Precio: {Price:C}\n" +
           $"Categoría: {Category}";
    }
}
