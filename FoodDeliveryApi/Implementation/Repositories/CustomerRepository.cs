using FoodDeliveryApi.Context;
using FoodDeliveryApi.Entities;
using FoodDeliveryApi.Interface.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FoodDeliveryApi.Implementation.Repositories
{
    public class CustomerRepository : RepositoryAsync,ICustomerRepository
    {
        private readonly ApplicationContext _dbContext;
        public CustomerRepository(ApplicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Customer> Delete(Customer customer, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (customer == null) throw new ArgumentNullException(null);
            _dbContext.Customers.Remove(customer);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return customer;
        }


        public async Task<IEnumerable<Customer>> GetAllCustomers()
        {
            IQueryable<Customer> query = _dbContext.Customers;
            return query.ToList();
        }

        public async Task<Customer> GetCustomer(Expression<Func<Customer, bool>> expression, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var customer = await _dbContext.Customers
                 .Include(cu => cu.User)
                .SingleOrDefaultAsync(expression, cancellationToken);
            return customer;
        }

        public async Task<Customer> Update(Customer customer, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (customer == null)
                throw new ArgumentNullException(null);
            _dbContext.Customers.Update(customer);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return customer;
        }
    }
}
