using FoodDeliveryApi.Context;
using FoodDeliveryApi.Entities;
using FoodDeliveryApi.Interface.Repositories;

namespace FoodDeliveryApi.Implementation.Repositories
{
    public class ProductRepository : RepositoryAsync, IProductRepository
    {
        private readonly ApplicationContext _dbContext;
        public ProductRepository(ApplicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
           IQueryable<Product> query = _dbContext.Products;
           return query.ToList();
        }
    }
}
