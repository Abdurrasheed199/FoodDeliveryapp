using FoodDeliveryApi.DTO_s;
using FoodDeliveryApi.DTO_s.CartDTO;
using FoodDeliveryApi.DTO_s.CustomerDTO;

namespace FoodDeliveryApi.Interface.Services
{
    public interface ICartService
    {
        Task <BaseResponse<string>> CreateCart(CreateCartRequestModel model, CancellationToken cancellationToken);
        Task <BaseResponse<CartDto>> GetCartById(string cartId, CancellationToken cancellationToken);
        Task <BaseResponse<CartDto>> DeleteCartById(string cartId,string userId, CancellationToken cancellationToken);
        
    }
}
