namespace FoodDeliveryApi.DTO_s.OrderDTO
{
    public class OrderResponseModel : BaseResponse<OrderDto>
    {
        public OrderDto Order { get; set; }
    }
}
