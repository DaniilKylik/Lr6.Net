using Lr6.Net.Interfaces;
using Lr6.Net.Models;

namespace Lr6.Net.Services
{
    public class ProductService : IProductService
    {
        public List<Product> GetProducts(int quantity)
        {
            var products = new List<Product>();
            for (int i = 0; i < quantity; i++)
            {
                products.Add(new Product { ProductName = $"Товар {i + 1}" });
            }
            return products;
        }
    }
}
