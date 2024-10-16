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
    public void Test1()
    {
        Assert.Pass();
    }
}