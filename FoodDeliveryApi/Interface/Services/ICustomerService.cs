using FoodDeliveryApi.DTO_s.CustomerDTO;

namespace FoodDeliveryApi.Interface.Services
{
    public interface ICustomerService
    {
        Task<CreateCustomerResponseModel> CreateCustomer(CreateCustomerRequestModel model, CancellationToken cancellationToken);
        Task<CustomerResponseModel> GetCustomer(string name);
        Task<CustomersResponseModel> GetCustomers();
    }
}
