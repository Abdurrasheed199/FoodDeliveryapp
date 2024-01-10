using FoodDeliveryApi.Context;
using FoodDeliveryApi.Entities;
using FoodDeliveryApi.Interface.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Threading;

namespace FoodDeliveryApi.Implementation.Repositories
{
    public class DeliveryRepository : RepositoryAsync, IDeliveryRepository
    {
        private readonly ApplicationContext _dbContext;

        public DeliveryRepository(ApplicationContext dbContext) : base(dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task<Delivery> Delete(Delivery delivery, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (delivery == null) throw new ArgumentNullException(null);
            _dbContext.Deliveries.Remove(delivery);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return delivery;
        }


        public async Task<IEnumerable<Delivery>> GetAllDeliveries(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var delivery = await _dbContext.Deliveries.Include(d => d.Customer).ToListAsync(cancellationToken);
            return delivery;
        }

        public async Task<Delivery> GetDelivery(Expression<Func<Delivery, bool>> expression, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var delivery = await _dbContext.Deliveries
                 .Include(c => c.Customer)
                .SingleOrDefaultAsync(expression, cancellationToken);
            return delivery;
        }

        public async Task<Delivery> GetDeliveryById(string deliveryId, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (string.IsNullOrEmpty(deliveryId)) throw new ArgumentNullException(nameof(deliveryId));
            cancellationToken.ThrowIfCancellationRequested();
            var delivery = await _dbContext.Deliveries
                 .Include(c => c.Customer)
                .SingleOrDefaultAsync(c => c.Id == deliveryId, cancellationToken);
            return delivery;
        }

        public async Task<Delivery> Update(Delivery delivery, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (delivery == null)
                throw new ArgumentNullException(null);
            _dbContext.Deliveries.Update(delivery);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return delivery;
        }
    }
}
