using FoodDeliveryApi.Entities;

namespace FoodDeliveryApi.Interface.Repositories
{
    public interface IUserRepository : IRepository
    {
        Task<IEnumerable<User>> GetAllUsers();
    }
}
