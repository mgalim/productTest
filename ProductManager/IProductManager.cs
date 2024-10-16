using ProductManager.Models;

namespace ProductManager
{
    public interface IProductManager
    {
        string AddProduct(Product product);

        Product? FindProductByName(string name);

        decimal CalculateTotalPrice(Product product);

        List<Product> GetAllProducts();

    }

}