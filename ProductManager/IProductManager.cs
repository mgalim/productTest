using ProductManager.Models;

namespace ProductManager
{
    public interface IProductManager
    {
        void AddProduct(Product product);

        Product? FindProductByName(string name);

        decimal CalculateTotalPrice(Product product);

    }

}