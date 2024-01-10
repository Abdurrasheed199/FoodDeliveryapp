using FoodDeliveryApi.Context;
using FoodDeliveryApi.Entities;
using FoodDeliveryApi.Interface.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FoodDeliveryApi.Implementation.Repositories
{
    public class CartRepository : RepositoryAsync, ICartRepository
    {
        private readonly ApplicationContext _dbContext;
        public CartRepository(ApplicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Cart> Delete(Cart cart, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (cart == null) throw new ArgumentNullException(null);
            _dbContext.Carts.Remove(cart);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return cart;
        }

        public async Task<IList<Cart>> GetAll(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var allCarts = await _dbContext.Carts.Include(cat => cat.ProductCarts).ThenInclude(p => p.Product).ToListAsync(cancellationToken);
            return allCarts;
        }

        public async Task<Cart> GetCart(Expression<Func<Cart, bool>> expression, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var cart = await _dbContext.Carts
                 .Include(sc => sc.ProductCarts)
                .SingleOrDefaultAsync(expression, cancellationToken);
            return cart;
        }

        public async Task<Cart> GetCartById(string cartId, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (string.IsNullOrEmpty(cartId)) throw new ArgumentNullException(nameof(cartId));
            cancellationToken.ThrowIfCancellationRequested();
            var cart = await _dbContext.Carts
                 .Include(sc => sc.ProductCarts)
                .SingleOrDefaultAsync(c => c.Id == cartId, cancellationToken);
            return cart;
        }

        public async Task<Cart> Update(Cart cart, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (cart == null)
            throw new ArgumentNullException(null);
             _dbContext.Carts.Update(cart);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return cart ;
        }
    }
}
