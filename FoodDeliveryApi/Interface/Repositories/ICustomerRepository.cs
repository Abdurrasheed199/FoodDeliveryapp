using FoodDeliveryApi.Entities;
using System.Linq.Expressions;

namespace FoodDeliveryApi.Interface.Repositories
{
    public interface ICustomerRepository : IRepository
    {
        Task<IEnumerable<Customer>> GetAllCustomers();
        Task<Customer> GetCustomer(Expression<Func<Customer, bool>> expression, CancellationToken cancellationToken);
        
        Task<Customer> Update(Customer customer, CancellationToken cancellationToken);
        Task<Customer> Delete(Customer customer, CancellationToken cancellationToken);
    }
}
