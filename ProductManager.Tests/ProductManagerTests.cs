using ProductManager.Models;

namespace ProductManager.Tests;

public class ProductManagerTests
{
    private IProductManager _productManager;

    [SetUp]
    public void Setup()
    {
        _productManager = new ProductManager();
    }

    [Test]
    public void CreateProduct_ValidData_CreatesProductSuccessfully()
    {
        Product product = new(1, "Pan de mesa", 2500.20m, ProductCategory.Alimentos);

        Assert.That(product, Is.Not.Null
        .And.Property("Id").EqualTo(1)
        .And.Property("Name").EqualTo("Pan de mesa")
        .And.Property("Price").EqualTo(2500.20m)
        .And.Property("Category").EqualTo(ProductCategory.Alimentos));
    }

    [Test]
    public void AddProduct_ValidData_AddsProductToListSuccessfully()
    {
        Product product = new(1, "Leche", 1300.20m, ProductCategory.Alimentos);
        string response = _productManager.AddProduct(product);
        int responseCount = _productManager.GetAllProducts().Count;
        int expectedCount = 1;

        Assert.Multiple(() =>
        {
            Assert.That(response, Is.EqualTo("Producto agregado con exito."));
            Assert.That(product, Is.EqualTo(_productManager.FindProductByName("Leche")));
            Assert.That(responseCount, Is.EqualTo(expectedCount));
        });
    }

    [Test]
    public void AddMultipleProducts_And_FindProductByName_WorksCorrectly()
    {
        Product product1 = new(1, "Harina", 1800.10m, ProductCategory.Alimentos);
        Product product2 = new(2, "Bateria", 65000.00m, ProductCategory.Electronica);

        _productManager.AddProduct(product1);
        _productManager.AddProduct(product2);

        Assert.Multiple(() =>
        {
            var foundProduct1 = _productManager.FindProductByName("Harina");
            Assert.That(foundProduct1, Is.EqualTo(product1), "No se encontró correctamente el producto 'Harina'.");

            var foundProduct2 = _productManager.FindProductByName("Bateria");
            Assert.That(foundProduct2, Is.EqualTo(product2), "No se encontró correctamente el producto 'Bateria'.");
        });
    }

    [Test]
    public void CalculateTotalPrice_Electronics_ReturnsTotalCorrectPrice()
    {
        List<Product> products = new()
        {
        new(1, "Calculadora", 20000m, ProductCategory.Electronica),
        new(2, "Mando PS4", 115499m, ProductCategory.Electronica),
        new(3, "Harina", 1800.10m, ProductCategory.Alimentos),
        };

        products.ForEach(p => _productManager.AddProduct(p));

        foreach (var product in _productManager.GetAllProducts())
        {
            if (product.Category == ProductCategory.Electronica)
            {
                decimal totalPrice = _productManager.CalculateTotalPrice(product);
                decimal expectedPrice = product.Price * 1.10m;
                Assert.That(totalPrice, Is.EqualTo(expectedPrice),
                $"El precio total para '{product.Name}' no es correcto.");
            }
        }
    }

    [Test]
    public void CalculateTotalPrice_Food_ReturnsTotalCorrectPrice()
    {
        List<Product> products = new()
        {
        new(1, "Pan de mesa", 22500.20m, ProductCategory.Alimentos),
        new(2, "Leche", 1530.80m, ProductCategory.Alimentos),
        new(3, "Pila AA", 2100.00m, ProductCategory.Electronica),
        };

        products.ForEach(p => _productManager.AddProduct(p));

        foreach (var product in _productManager.GetAllProducts())
        {
            if (product.Category == ProductCategory.Alimentos)
            {
                decimal totalPrice = _productManager.CalculateTotalPrice(product);
                decimal expectedPrice = product.Price * 1.05m;
                Assert.That(totalPrice, Is.EqualTo(expectedPrice));
            }
        }
    }
}