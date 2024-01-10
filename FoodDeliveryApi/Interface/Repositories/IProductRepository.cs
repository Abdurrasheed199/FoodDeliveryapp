using FoodDeliveryApi.Entities;

namespace FoodDeliveryApi.Interface.Repositories
{
    public interface IProductRepository : IRepository
    {
        Task<IEnumerable<Product>> GetAllProducts();
    }
}
