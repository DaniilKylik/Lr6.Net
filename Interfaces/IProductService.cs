using Lr6.Net.Models;

namespace Lr6.Net.Interfaces
{
    public interface IProductService
    {
        List<Product> GetProducts(int quantity);
    }
}
