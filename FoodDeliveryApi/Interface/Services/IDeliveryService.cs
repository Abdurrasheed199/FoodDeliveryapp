using FoodDeliveryApi.DTO_s;
using FoodDeliveryApi.DTO_s.CustomerDTO;
using FoodDeliveryApi.DTO_s.DeliveryDTO;

namespace FoodDeliveryApi.Interface.Services
{
    public interface IDeliveryService
    {
        Task<CreateDeliveryResponseModel> CreateDelivery(CreateDeliveryRequestModel model, CancellationToken cancellationToken);
        Task<BaseResponse<DeliveryDto>> GetDelivery(string name, CancellationToken cancellationToken);
        Task<BaseResponse<IEnumerable<DeliveryDto>>> GetDeliviries(CancellationToken cancellationToken);
    }
}
