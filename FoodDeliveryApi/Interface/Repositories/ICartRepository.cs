using FoodDeliveryApi.Entities;
using System.Linq.Expressions;

namespace FoodDeliveryApi.Interface.Repositories
{
    public interface ICartRepository : IRepository
    {
        Task<Cart> GetCartById(string cartId, CancellationToken cancellationToken);
        Task<Cart> GetCart(Expression<Func<Cart, bool>> expression, CancellationToken cancellationToken);
        Task<IList<Cart>> GetAll(CancellationToken cancellationToken);
        Task<Cart> Update(Cart cart, CancellationToken cancellationToken);
        Task<Cart> Delete(Cart cart, CancellationToken cancellationToken);

    }
}