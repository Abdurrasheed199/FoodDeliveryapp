using FoodDeliveryApi.Entities;
using System.Linq.Expressions;

namespace FoodDeliveryApi.Interface.Repositories
{
    public interface IOrderRepository : IRepository
    {
        Task<Order> GetOrderById(string orderId, CancellationToken cancellationToken);
        Task<IList<Order>> GetAllOrders(CancellationToken cancellationToken);
        Task<Order> Add(Order order, CancellationToken cancellationToken);
        Task<Order> Update(Order order, CancellationToken cancellationToken);
        Task<Order> Get(Expression<Func<Order, bool>> expression, CancellationToken cancellationToken);
        Task<Order> GetByDate(DateTime date, CancellationToken cancellationToken);
        Task<IList<Order>> GetAllAsync(Expression<Func<Order, bool>> expression, CancellationToken cancellationToken);


    }
}
