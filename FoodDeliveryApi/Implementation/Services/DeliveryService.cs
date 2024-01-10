using FoodDeliveryApi.DTO_s;
using FoodDeliveryApi.DTO_s.CustomerDTO;
using FoodDeliveryApi.DTO_s.DeliveryDTO;
using FoodDeliveryApi.DTO_s.UserDTO;
using FoodDeliveryApi.Entities;
using FoodDeliveryApi.Interface.Repositories;
using FoodDeliveryApi.Interface.Services;

namespace FoodDeliveryApi.Implementation.Services
{
    public class DeliveryService : IDeliveryService
    {
        private readonly IDeliveryRepository _deliveryRepository;
        private readonly ICustomerRepository _customerRepository;

        public DeliveryService(IDeliveryRepository deliveryRepository, ICustomerRepository customerRepository)
        {
            _deliveryRepository = deliveryRepository;
            _customerRepository = customerRepository;
        }

        public async Task<CreateDeliveryResponseModel> CreateDelivery(CreateDeliveryRequestModel model, CancellationToken cancellationToken)
        {
            CreateDeliveryResponseModel createDeliveryResponseModel = new();

            var Delivered = await _deliveryRepository.ExistsAsync<Customer>(cus => cus.Id == model.CustomerId);
            if(Delivered)
            {
                createDeliveryResponseModel.Message = "customer is Available Delivery Soon";
                createDeliveryResponseModel.Status = true;

                var delivered = new Delivery(model.Delivered, model.CustomerId);
                return createDeliveryResponseModel;
            }
            createDeliveryResponseModel.Message = " Customer Not Available";
            createDeliveryResponseModel.Status = false;

            return createDeliveryResponseModel;

        }

        public async Task<BaseResponse<DeliveryDto>> GetDelivery(string name, CancellationToken cancellationToken)
        {
            DeliveryDto deliveryDto = new();
            var delivery = await _deliveryRepository.GetAsync<Delivery>(d => d.Customer.FullName == name);
            if (delivery == null)
            {
                return new BaseResponse<DeliveryDto>
                {
                    Message = "Delivery Not available",
                    Status = false
                };
                
            }

            return new BaseResponse<DeliveryDto>
            {
                Data = new DeliveryDto
                {
                    Id = delivery.Id,
                    Customer = new CustomerDto
                    {
                        Id = delivery.Id,
                        FullName = delivery.Customer.FullName,
                        Email = delivery.Customer.Email,
                        Address = delivery.Customer.Address,

                    },

                },
                Message = "Delivered Successfully",
                Status = true,

            };

        }

        public async Task<BaseResponse<IEnumerable<DeliveryDto>>> GetDeliviries(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var deliviries = await _deliveryRepository.GetAllDeliveries(cancellationToken);
            if (deliviries == null) return new BaseResponse<IEnumerable<DeliveryDto>>
            {
                Message = "No Messages",
                Status = false
            };
            return new BaseResponse<IEnumerable<DeliveryDto>>
            {
                Data = deliviries.Select(n => new DeliveryDto
                {
                    Id = n.Id,
                    Customer = new CustomerDto
                    {
                        Id = n.Id,
                        FullName = n.Customer.FullName,
                        Email = n.Customer.Email,
                        Address = n.Customer.Address,

                    },

                }).ToList(),
                Message = "Successful",
                Status = true
            };

        }


    }
}
