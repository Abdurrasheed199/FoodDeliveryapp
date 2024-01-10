using FoodDeliveryApi.DTO_s;
using FoodDeliveryApi.DTO_s.OrderDTO;

namespace FoodDeliveryApi.Interface.Services
{
    public interface IOrderService
    {
        Task<BaseResponse<OrderDto>> Create(string cartId, string userId, CancellationToken cancellationToken);
        Task<BaseResponse<IList<OrderDto>>> GetAll(string userId, CancellationToken cancellationToken);
        Task<BaseResponse<IList<OrderDto>>> GetByDate(string date, CancellationToken cancellationToken);
        Task<BaseResponse<IList<OrderDto>>> GetNonApprovedOrders(CancellationToken cancellationToken);
        Task<BaseResponse<IList<OrderDto>>> GetAllApprovedOrder(CancellationToken cancellationToken);
        Task<BaseResponse<OrderDto>> ApproveOrder(string orderId, CancellationToken cancellationToken);
    }
}
