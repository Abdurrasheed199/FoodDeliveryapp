using FoodDeliveryApi.Entities;
using System.Linq.Expressions;
using System.Threading;

namespace FoodDeliveryApi.Interface.Repositories
{
    public interface IDeliveryRepository : IRepository
    {
        Task<IEnumerable<Delivery>> GetAllDeliveries(CancellationToken cancellationToken);
        Task<Delivery> GetDeliveryById(string deliveryId, CancellationToken cancellationToken);
        Task<Delivery> GetDelivery(Expression<Func<Delivery, bool>> expression, CancellationToken cancellationToken);
        Task<Delivery> Update(Delivery delivery, CancellationToken cancellationToken);
        Task<Delivery> Delete(Delivery delivery, CancellationToken cancellationToken);
    }
}
