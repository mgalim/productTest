using ProductManager.Models;

namespace ProductManager;

public class ProductManager : IProductManager
{
    private readonly List<Product> _products;

    public ProductManager()
    {
        _products = [];
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public Decimal CalculateTotalPrice(Product product)
    {
        decimal tax = product.Category == ProductCategory.Electronica ? 0.10m : 0.05m;
        return product.Price * (1 + tax);
    }

    public Product? FindProductByName(string name)
    {
        return _products?.Find(p => p.Name == name);
    }

}