using FoodDeliveryApi.Context;
using FoodDeliveryApi.Entities;
using FoodDeliveryApi.Interface.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FoodDeliveryApi.Implementation.Repositories
{
    public class OrderRepository : RepositoryAsync, IOrderRepository
    {
        private readonly ApplicationContext _dbContext;
        public OrderRepository(ApplicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Order> Add(Order order, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (order == null) throw new ArgumentNullException(null);
            await _dbContext.Orders.AddAsync(order, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return order;
        }

        public async Task<Order> Get(Expression<Func<Order, bool>> expression, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var order = await _dbContext.Orders
              .Include(s => s.Cart)
              .ThenInclude(s => s.ProductCarts)
              .Include(or => or.User)
              .SingleOrDefaultAsync(expression, cancellationToken);
            return order;
        }

        public async Task<IList<Order>> GetAllAsync(Expression<Func<Order, bool>> expression, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var order = await _dbContext.Orders
                .Include(s => s.Cart)
                .ThenInclude(s => s.ProductCarts)
                .Include(or => or.User)
                .Where(expression)
                .ToListAsync(cancellationToken);
            return order;
        }

        public async Task<IList<Order>> GetAllOrders(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var order = await _dbContext.Orders
                .Include(s => s.Cart)
                .ThenInclude(s => s.ProductCarts)
                .ToListAsync(cancellationToken);
            return order;
        }

        
        public async Task<Order> GetByDate(DateTime date, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            date = date.ToUniversalTime();
            var order = await _dbContext.Orders
                .Include(s => s.Cart)
                .ThenInclude(s => s.ProductCarts)
                .Include(or => or.User)
                .SingleOrDefaultAsync(p => p.CreatedOn == date, cancellationToken);
            return order;
        }

        public async Task<Order> GetOrderById(string orderId, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (string.IsNullOrEmpty(orderId)) throw new ArgumentNullException(nameof(orderId));
            cancellationToken.ThrowIfCancellationRequested();
            var order = await _dbContext.Orders
                 .Include(s => s.Cart)
                 .ThenInclude(sc => sc.ProductCarts)
                 
                .SingleOrDefaultAsync(or => or.Id == orderId, cancellationToken);
            return order;
        }

        public async Task<Order> Update(Order order, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (order == null) throw new ArgumentNullException(null);
            _dbContext.Orders.Update(order);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return order;
        }
    }
}
