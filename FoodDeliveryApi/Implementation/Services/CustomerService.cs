using FoodDeliveryApi.DTO_s.CustomerDTO;
using FoodDeliveryApi.DTO_s.UserDTO;
using FoodDeliveryApi.Entities;
using FoodDeliveryApi.Interface.Repositories;
using FoodDeliveryApi.Interface.Services;

namespace FoodDeliveryApi.Implementation.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUserRepository _userRepository;

       public CustomerService(ICustomerRepository customerRepository, IUserRepository userRepository)
        {
            _customerRepository = customerRepository;
            _userRepository = userRepository;
        }

        public async Task<CreateCustomerResponseModel> CreateCustomer(CreateCustomerRequestModel model, CancellationToken cancellationToken)
        {
            CreateCustomerResponseModel createCustomerResponseModel = new();

            var customerExist = await _customerRepository.ExistsAsync<Customer>(c => c.FullName == model.FullName);
            if (customerExist)
            {
                createCustomerResponseModel.Status = false;
                createCustomerResponseModel.Message = " Customer Already Exist";

                return createCustomerResponseModel;

            }

            var user = new User(model.FirstName, model.LastName, model.Email, model.Password,model.Username);
            var userId = await _userRepository.CreateAsync<User>(user);
            await _userRepository.SaveChangesAsync();
            var customer = new Customer(model.FullName, model.PhoneNumber, model.Email, model.Address, userId);
            var customerId = await _customerRepository.CreateAsync<Customer>(customer);
            await _customerRepository.SaveChangesAsync();
            createCustomerResponseModel.Message = " Customer Created";
            createCustomerResponseModel.Status = true;
            return createCustomerResponseModel;

        }

        public async Task<CustomerResponseModel> GetCustomer(string name)
        {
            CustomerResponseModel customerResponseModel = new();
            var customer = await _customerRepository.GetAsync<Customer>(c => c.FullName == name);
            if (customer == null)
            {
                customerResponseModel.Message = "Customer does not exist";
                customerResponseModel.Status = false;
                return customerResponseModel;
            }
            
            CustomerDto customerDto = new();
            customerDto.Address = customer.Address;
            customerDto.PhoneNumber = customer.PhoneNumber;
            customerDto.FullName = customer.FullName;
            customerDto.Email = customer.Email;
            customerDto.Id = customer.Id;
            customerDto.User = new UserDto

            {
                
                FirstName = customer.User.FirstName,
                LastName = customer.User.LastName,
                Email = customer.User.Email,
                Password = customer.User.Password,
                Username = customer.User.Username

            };
            customerResponseModel.Customer = customerDto;
            customerResponseModel.Status = true;
            customerResponseModel.Message = "Customer found successfully";
            return customerResponseModel;

        }

        public async Task<CustomersResponseModel> GetCustomers()
        {
            CustomersResponseModel customersResponseModel = new();
            var customers = await _customerRepository.GetAllCustomers();
            if (customers == null)
            {
                customersResponseModel.Message = "No customer student";
                customersResponseModel.Status = false;
                return customersResponseModel;
            }
            customersResponseModel.Customers = customers.Select(s => new CustomerDto
            {
                Id = s.Id,
                Email = s.Email,
                PhoneNumber = s.PhoneNumber,
                FullName = s.FullName,
                Address = s.Address,
                User = new UserDto
                {
                    FirstName= s.User.FirstName,
                    LastName= s.User.LastName,
                    Email = s.User.Email,
                    Password = s.User.Password,
                    Username = s.User.Username
                    
                }
            }).ToList();
            customersResponseModel.Message = "Succesfull";
            customersResponseModel.Status = true;
            return customersResponseModel;
        }
    }
}
