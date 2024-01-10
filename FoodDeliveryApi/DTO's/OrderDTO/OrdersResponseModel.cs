namespace FoodDeliveryApi.DTO_s.OrderDTO
{
    public class OrdersResponseModel : BaseResponse<List<OrderDto>>
    {
        public List<OrderDto> Orders { get; set;}
    }
}
