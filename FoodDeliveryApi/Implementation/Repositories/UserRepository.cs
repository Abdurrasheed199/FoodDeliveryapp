using FoodDeliveryApi.Context;
using FoodDeliveryApi.Entities;
using FoodDeliveryApi.Interface.Repositories;

namespace FoodDeliveryApi.Implementation.Repositories
{
    public class UserRepository : RepositoryAsync, IUserRepository
    {
        private readonly ApplicationContext _dbContext;
        public UserRepository(ApplicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<IEnumerable<User>> GetAllUsers()
        {
            throw new NotImplementedException();
        }
    }
}
